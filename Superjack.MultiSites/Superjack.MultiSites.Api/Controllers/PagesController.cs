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
using System.Text.Json;

namespace Superjack.MultiSites.Api.Controllers
{
  //[Authorize]
  [ApiController]
  [Route("[controller]")]
  public class PagesController : ControllerBase
  {

    private IMapper _mapper;
    private readonly ILogger<PagesController> _logger;
    private IPageService _service;
    private IPageBlockService _pageBlockService;
    private IBlockService _blockService;
    private IBlockFieldService _blockFieldService;
    private IPageFieldService _pageFieldService;

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
    [Route("~/pages/tree/{siteid}")]
    public IActionResult GetTreeBySiteId(long siteid)
    {
      var roots = _service.GetRootNestedSitePages(siteid);
      var pages = new List<PageDto>();
      var root = roots!=null && roots.Count()>0 ? _mapper.Map<PageDto>(roots.ToArray()[0]) : null;
      if(root!=null && roots.Count() > 1)
      {
        var versionRoots = roots.Skip(1);
        root.Versions = versionRoots.Any() ? _mapper.Map<PageDto[]>(versionRoots) : new List<PageDto>().ToArray();
      }

      var children = GetNestedChildrenPages(siteid, root.Level + 1, root.PageIdentifier);
      root.Children = children.ToArray();
      pages.Add(root);

      return Ok(pages);
    }

    

    private PageDto[] GetNestedChildrenPages(long siteid, int level, string parentPageIdentifier)
    {
      var children = _service.GetNestedChildrenPages(siteid, level, parentPageIdentifier);
      var childrenPages = new List<PageDto>();
      if (children.Any())
      {
        var pages = children.AsEnumerable().GroupBy(item => item.PageIdentifier)
               .SelectMany(grouping => grouping.Take(1));
        foreach(var p in pages)
        {
          var childPage = _mapper.Map<PageDto>(p);
          childPage.Versions = GetVersionPages(childPage.PageIdentifier, children);
          childPage.Children = GetNestedChildrenPages(siteid, level + 1, childPage.PageIdentifier);
          childrenPages.Add(childPage);
        }        
      }
      return childrenPages.ToArray();
    }

    private PageDto[] GetVersionPages(string pageIdentifier, IEnumerable<Page> children)
    {
      var versions = children.Where(x => x.PageIdentifier == pageIdentifier).Skip(1);
      return _mapper.Map<PageDto[]>(versions);
    }




    [HttpPost]
    [Route("~/pages/querysearch")]
    public IActionResult GetAllByQuery([FromBody] PageSearchFilterDto itemDto)
    {
      try
      {
       
        var items = _service.Search(itemDto);
        var itemDtos = _mapper.Map<IList<PageDto>>(items);

        return Ok(itemDtos);
        
      }
      catch (Exception ex)
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
