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
    private IBlockService _blockService;
    private IBlockFieldService _blockFieldService;
    private IPageFieldService _pageFieldService;

    public PageBlocksController(IMapper mapper, ILogger<PageBlocksController> logger, IPageBlockService service,
      IBlockService blockService, IBlockFieldService blockFieldService,
      IPageFieldService pageFieldService)
    {
      _mapper = mapper;
      _logger = logger;
      _service = service;
      _blockService = blockService;
      _blockFieldService = blockFieldService;
      _pageFieldService = pageFieldService;
    }

    [HttpGet]
    public IActionResult Get()
    {

      var items = _service.GetAll();
      var itemDtos = _mapper.Map<IList<PageBlockDto>>(items);

      return Ok(itemDtos);
    }

    private PageBlockDto[] GetPageBlocks(long pageId, long parentId, int level)
    {
      var pageBlocks = _service.GetAllByPageIdAndLevel(pageId, parentId, level);
      var pageBlockDtos = _mapper.Map<IList<PageBlockDto>>(pageBlocks);
      foreach (var pb in pageBlockDtos)
      {
        var block = _blockService.GetById(pb.BlockId);
        var blockDto = _mapper.Map<BlockDto>(block);
        pb.Block = blockDto;

        var pageFields = _pageFieldService.GetAllByPageBlockId(pb.Id);
        var pageFieldDtos = _mapper.Map<IList<PageFieldDto>>(pageFields);

        foreach (var pf in pageFieldDtos)
        {
          var blockField = _blockFieldService.GetById(pf.FieldId);
          var blockFieldDto = _mapper.Map<BlockFieldDto>(blockField);
          pf.BlockField = blockFieldDto;
        }

        pb.Fields = pageFieldDtos.ToArray();

        var children = GetPageBlocks(pageId, pb.Id, level + 1);
        pb.Children = children.Any() ? children : new List<PageBlockDto>().ToArray();
      }

      return pageBlockDtos.ToArray();
    }

    [HttpGet]
    [Route("~/pageblocks/pageid/{pageid}")]
    public IActionResult GetAllByPageId(long pageid)
    {
      var itemDtos = GetPageBlocks(pageid, 0, 0);
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
