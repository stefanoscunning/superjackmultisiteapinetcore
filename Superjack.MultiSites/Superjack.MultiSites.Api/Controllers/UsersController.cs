using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Superjack.MultiSites.Api.DataAccess;
using Superjack.MultiSites.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Superjack.MultiSites.Api.Dtos;
using Superjack.MultiSites.Api.Helpers;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace Superjack.MultiSites.Api.Controllers
{
  [Authorize]
  [ApiController]
  [Route("[controller]")]
  public class UsersController : ControllerBase
  {

    private IMapper _mapper;
    private readonly ILogger<UsersController> _logger;
    private IUserService _service;
    private readonly AppSettings _appSettings;
    private IOptions<Encryption> _encryption;

    public UsersController(IMapper mapper, ILogger<UsersController> logger, IUserService service, IOptions<AppSettings> appSettings,
            IOptions<Encryption> encryption)
    {
      _mapper = mapper;
      _logger = logger;
      _service = service;
      _appSettings = appSettings.Value;
      _encryption = encryption;
    }

    [HttpGet]
    public IActionResult Get()
    {

      var items = _service.GetAll();
      var itemDtos = _mapper.Map<IList<UserDto>>(items);

      return Ok(itemDtos);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(long id)
    {

      var item = _service.GetById(id);
      var itemDto = _mapper.Map<UserDto>(item);
      return Ok(itemDto);
    }

    [AllowAnonymous]
    [HttpPost]
    [Route("~/users/authenticate")]
    public IActionResult Authenticate([FromBody] UserDto userDto)
    {
      
      var user = _service.Authenticate(Base64Coding.Base64Decode(userDto.Username), Base64Coding.Base64Decode(userDto.Password));

      if (user == null)
        return BadRequest(new { message = "Username or password is incorrect" });

      var tokenHandler = new JwtSecurityTokenHandler();
      var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(new Claim[]
          {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
          }),
        Expires = DateTime.UtcNow.AddDays(7),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
      };
      var token = tokenHandler.CreateToken(tokenDescriptor);
      var tokenString = tokenHandler.WriteToken(token);

      // return basic user info (without password) and token to store client side
      return Ok(new
      {
        Id = user.Id,
        Username = user.Username,
        FirstName = user.FirstName,
        Surname = user.Surname,
        Token = tokenString,
        
      });
    }

    [HttpPost]
    public IActionResult Create([FromBody] UserDto itemDto)
    {
      var item = _mapper.Map<User>(itemDto);
      try
      {
        var newitem = _service.Create(item, "Superjack1");
        var newItemDto = _mapper.Map<UserDto>(newitem);
        return Ok(newItemDto);
      }
      catch (Exception ex)
      {
        return BadRequest(new { message = ex.Message });
      }
    }

    [HttpPut("{id}")]
    public IActionResult Update(string id, [FromBody] UserDto itemDto)
    {
      // map dto to entity and set id
      var item = _mapper.Map<User>(itemDto);

      try
      {
        // save 
        _service.Update(item);
        return Ok();
      }
      catch (Exception ex)
      {
        // return error message if there was an exception
        return BadRequest(new { message = ex.Message });
      }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
      _service.Delete(id);
      return Ok();
    }



  }
}
