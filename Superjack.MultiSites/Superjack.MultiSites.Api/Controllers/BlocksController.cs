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
  public class BlocksController : ControllerBase
  {

    private IMapper _mapper;
    private readonly ILogger<BlocksController> _logger;
    private IBlockService _service;

    public BlocksController(IMapper mapper, ILogger<BlocksController> logger, IBlockService service)
    {
      _mapper = mapper;
      _logger = logger;
      _service = service;
    }

    [HttpGet]
    public IActionResult Get()
    {

      var items = _service.GetAll();
      var itemDtos = _mapper.Map<IList<BlockDto>>(items);

      return Ok(itemDtos);
    }

    [HttpGet]
    [Route("~/blocks/all")]
    public IActionResult GetAll()
    {

      var items = _service.GetAll();
      var itemDtos = _mapper.Map<IList<BlockDto>>(items);

      return Ok(itemDtos);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(long id)
    {

      var item = _service.GetById(id);
      var itemDto = _mapper.Map<BlockDto>(item);
      return Ok(itemDto);
    }

    [HttpPost]
    public IActionResult Create([FromBody] BlockDto itemDto)
    {
      var item = _mapper.Map<Block>(itemDto);
      try
      {
        var newitem = _service.Create(item);
        var newItemDto = _mapper.Map<BlockDto>(newitem);
        return Ok(newItemDto);
      }
      catch (Exception ex)
      {
        return BadRequest(new { message = ex.Message });
      }
    }

    [HttpPut("{id}")]
    public IActionResult Update(string id, [FromBody] BlockDto itemDto)
    {
      // map dto to entity and set id
      var item = _mapper.Map<Block>(itemDto);

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
    [Route("~/blocks/uuid/{uuid}")]
    public IActionResult DeleteByUuid(string uuid)
    {
      var item = _service.GetByUuid(uuid);
      return Delete(item.Id);

    }




  }
}
