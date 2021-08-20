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

namespace Superjack.MultiSites.Api.Controllers
{
  [Authorize]
  [ApiController]
  [Route("[controller]")]
  public class SitesController : ControllerBase
  {

    private IMapper _mapper;
    private readonly ILogger<SitesController> _logger;
    private ISiteService _service;

    public SitesController(IMapper mapper, ILogger<SitesController> logger, ISiteService service)
    {
      _mapper = mapper;
      _logger = logger;
      _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Site>>> GetSites()
    {
      var list = await _service.GetAllAsync();

      return Ok(list);
    }

    [HttpGet]
    [Route("~/sites/all")]
    public IActionResult Get()
    {

      var items = _service.GetAll();
      var itemDtos = _mapper.Map<IList<SiteDto>>(items);

      return Ok(itemDtos);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(long id)
    {

      var item = _service.GetById(id);
      var itemDto = _mapper.Map<SiteDto>(item);
      return Ok(itemDto);
    }

    [HttpPost]
    public IActionResult Create([FromBody] SiteDto itemDto)
    {
      var item = _mapper.Map<Site>(itemDto);
      try
      {
        var newitem = _service.Create(item);
        var newItemDto = _mapper.Map<SiteDto>(newitem);
        return Ok(newItemDto);
      }
      catch (Exception ex)
      {
        return BadRequest(new { message = ex.Message });
      }
    }

    [HttpPut("{id}")]
    public IActionResult Update(string id, [FromBody] SiteDto itemDto)
    {
      // map dto to entity and set id
      var item = _mapper.Map<Site>(itemDto);

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

    [HttpDelete]
    [Route("~/sites/uuid/{uuid}")]
    public IActionResult DeleteByUuid(string uuid)
    {
      var item = _service.GetByUuid(uuid);
      return Delete(item.Id);
      
    }



  }
}
