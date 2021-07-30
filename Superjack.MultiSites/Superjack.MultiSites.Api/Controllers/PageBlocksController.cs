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
  public class PageBlocksController : ControllerBase
  {

    private IMapper _mapper;
    private readonly ILogger<PageBlocksController> _logger;
    private IPageBlockService _service;

    public PageBlocksController(IMapper mapper, ILogger<PageBlocksController> logger, IPageBlockService service)
    {
      _mapper = mapper;
      _logger = logger;
      _service = service;
    }

    [HttpGet]
    public IActionResult Get()
    {

      var items = _service.GetAll();
      var itemDtos = _mapper.Map<IList<PageBlockDto>>(items);

      return Ok(itemDtos);
    }

    [HttpGet]
    [Route("~/pageblocks/pageid/{pageid}")]
    public IActionResult GetAllByPageId(long pageid)
    {

      var items = _service.GetAllByPageId(pageid);
      var itemDtos = _mapper.Map<IList<PageBlockDto>>(items);

      return Ok(itemDtos);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(long id)
    {

      var item = _service.GetById(id);
      var itemDto = _mapper.Map<PageBlockDto>(item);
      return Ok(itemDto);
    }

    [HttpPost]
    public IActionResult Create([FromBody] PageBlockDto itemDto)
    {
      var item = _mapper.Map<PageBlock>(itemDto);
      try
      {
        var newitem = _service.Create(item);
        var newItemDto = _mapper.Map<PageBlockDto>(newitem);
        return Ok(newItemDto);
      }
      catch (Exception ex)
      {
        return BadRequest(new { message = ex.Message });
      }
    }

    [HttpPut("{id}")]
    public IActionResult Update(string id, [FromBody] PageBlockDto itemDto)
    {
      // map dto to entity and set id
      var item = _mapper.Map<PageBlock>(itemDto);

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
