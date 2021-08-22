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
  public class BlockFieldsController : ControllerBase
  {

    private IMapper _mapper;
    private readonly ILogger<BlockFieldsController> _logger;
    private IBlockFieldService _service;

    public BlockFieldsController(IMapper mapper, ILogger<BlockFieldsController> logger, IBlockFieldService service)
    {
      _mapper = mapper;
      _logger = logger;
      _service = service;
    }

    [HttpGet]
    public IActionResult Get()
    {

      var items = _service.GetAll();
      var itemDtos = _mapper.Map<IList<BlockFieldDto>>(items);

      return Ok(itemDtos);
    }

    [HttpGet]
    [Route("~/blockfields/blockid/{blockid}")]
    public IActionResult GetAllByBlockId(long blockid)
    {

      var items = _service.GetAllByBlockId(blockid);
      var itemDtos = _mapper.Map<IList<BlockFieldDto>>(items);

      return Ok(itemDtos);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(long id)
    {

      var item = _service.GetById(id);
      var itemDto = _mapper.Map<BlockFieldDto>(item);
      return Ok(itemDto);
    }

    [HttpPost]
    public IActionResult Create([FromBody] BlockFieldDto itemDto)
    {
      var item = _mapper.Map<BlockField>(itemDto);
      try
      {
        var newitem = _service.Create(item);
        var newItemDto = _mapper.Map<BlockFieldDto>(newitem);
        return Ok(newItemDto);
      }
      catch (Exception ex)
      {
        return BadRequest(new { message = ex.Message });
      }
    }

    [HttpPut("{id}")]
    public IActionResult Update(string id, [FromBody] BlockFieldDto itemDto)
    {
      // map dto to entity and set id
      var item = _mapper.Map<BlockField>(itemDto);

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

    [HttpPut]
    [Route("~/blockfields/blockid/{blockid}")]
    public IActionResult UpdateAll(string blockid, [FromBody] BlockFieldDto[] itemsDto)
    {
      // map dto to entity and set id

      try
      {
        foreach (var itemDto in itemsDto)
        {
          var item = _mapper.Map<BlockField>(itemDto);
          _service.Update(item);
        }
        // save 

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
    [Route("~/blockfields/uuid/{uuid}")]
    public IActionResult DeleteByUuid(string uuid)
    {
      var item = _service.GetByUuid(uuid);
      return Delete(item.Id);

    }



  }
}
