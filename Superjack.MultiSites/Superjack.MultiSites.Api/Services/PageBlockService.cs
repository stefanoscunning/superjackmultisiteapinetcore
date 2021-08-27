using Superjack.MultiSites.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Superjack.MultiSites.Api.Services
{
  public interface IPageBlockService
  {
    IEnumerable<PageBlock> GetAll();
    IEnumerable<PageBlock> GetAllByPageId(long pageId);
    IEnumerable<PageBlock> GetAllByPageIdAndLevel(long pageId, long parentId, int level);
    PageBlock GetById(long id);
    PageBlock Create(PageBlock item);
    void Update(PageBlock newitem);
    void Delete(long id);

  }
  public class PageBlockService : IPageBlockService
  {
    private AppDbContext _context;

    public PageBlockService(AppDbContext context)
    {
      _context = context;
    }

    public IEnumerable<PageBlock> GetAll()
    {
      return _context.PageBlocks.OrderBy(x=>x.PageId).ThenBy(x=>x.SortOrder);
    }

    public IEnumerable<PageBlock> GetAllByPageId(long pageId)
    {
      return _context.PageBlocks.Where(x=>x.PageId==pageId).OrderBy(x=>x.SortOrder);
    }

    public IEnumerable<PageBlock> GetAllByPageIdAndLevel(long pageId, long parentId, int level)
    {
      return _context.PageBlocks.Where(x => x.PageId == pageId && x.ParentId==parentId && x.Level==level).OrderBy(x => x.SortOrder);
    }

    public PageBlock GetById(long id)
    {
      return _context.PageBlocks.Find(id);
    }

    public PageBlock Create(PageBlock item)
    {

      _context.PageBlocks.Add(item);
      _context.SaveChanges();

      return item;
    }

    public void Update(PageBlock newitem)
    {
      var item = _context.PageBlocks.Find(newitem.Id);

      item.BlockId = newitem.BlockId;
      item.PageId = newitem.PageId;
      item.ParentId = newitem.ParentId;
      item.SortOrder = newitem.SortOrder;

      // update PageBlock properties

      _context.PageBlocks.Update(item);
      _context.SaveChanges();
    }

    public void Delete(long id)
    {
      var item = _context.PageBlocks.Find(id);
      if (item != null)
      {
        _context.PageBlocks.Remove(item);
        _context.SaveChanges();
      }
    }

  }
}
