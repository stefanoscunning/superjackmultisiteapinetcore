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
  public class PagesController : ControllerBase
  {

    private IMapper _mapper;
    private readonly ILogger<PagesController> _logger;
    private IPageService _service;

    public PagesController(IMapper mapper, ILogger<PagesController> logger, IPageService service)
    {
      _mapper = mapper;
      _logger = logger;
      _service = service;
    }

    [HttpGet]
    public IActionResult Get()
    {

      var items = _service.GetAll();
      var itemDtos = _mapper.Map<IList<PageDto>>(items);

      return Ok(itemDtos);
    }

    [HttpGet]
    [Route("~/pages/siteid/{siteid}")]
    public IActionResult GetAllBySiteId(long siteid)
    {

      var items = _service.GetAllBySiteId(siteid);
      var itemDtos = _mapper.Map<IList<PageDto>>(items);

      return Ok(itemDtos);
    }

    [HttpGet]
    [Route("~/pages/query")]
    //public IActionResult GetAllByQuery([FromBody] dynamic itemDto)
    public IActionResult GetAllByQuery()
    {
      try
      {
        
        var filters = new
        {
          //PageIdentifier = new {
          //  Comparison = "contains",
          //  Query = "48b"
          //},
          //ParentPageIdentifier = new 
          //{
          //  Comparison = "==",
          //  Query = "97d0f17a-6fd1-4acc-94d4-18198c9af795"
          //},
          DateScheduledPublish = new
          {
            Comparison = "notnull",
            Query = DateTime.Now
          },
          DateScheduledExpiry = new
          {
            Comparison = "current",
            Query = DateTime.Now
          },
          SiteId = 1,
          Published = true,
          Disabled = false,
          Binned = false
          
        };
        var items = _service.Search(filters);
        var itemDtos = _mapper.Map<IList<PageDto>>(items);

        return Ok(itemDtos);
      }
      catch
      {

        return BadRequest();
      }
     
    }

    [HttpGet("{id}")]
    public IActionResult GetById(long id)
    {

      var item = _service.GetById(id);
      var itemDto = _mapper.Map<PageDto>(item);
      return Ok(itemDto);
    }

    [HttpPost]
    public IActionResult Create([FromBody] PageDto itemDto)
    {
      var item = _mapper.Map<Page>(itemDto);
      try
      {
        var newitem = _service.Create(item);
        var newItemDto = _mapper.Map<PageDto>(newitem);
        return Ok(newItemDto);
      }
      catch (Exception ex)
      {
        return BadRequest(new { message = ex.Message });
      }
    }

    [HttpPut("{id}")]
    public IActionResult Update(string id, [FromBody] PageDto itemDto)
    {
      // map dto to entity and set id
      var item = _mapper.Map<Page>(itemDto);

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
