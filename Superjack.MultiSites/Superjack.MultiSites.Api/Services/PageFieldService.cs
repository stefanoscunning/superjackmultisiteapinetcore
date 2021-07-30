using Superjack.MultiSites.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Superjack.MultiSites.Api.Services
{
  public interface IPageFieldService
  {
    IEnumerable<PageField> GetAll();
    IEnumerable<PageField> GetAllByPageBlockId(long pageBlockId);
    PageField GetById(long id);
    PageField Create(PageField item);
    void Update(PageField newitem);
    void Delete(long id);

  }
  public class PageFieldService : IPageFieldService
  {
    private AppDbContext _context;

    public PageFieldService(AppDbContext context)
    {
      _context = context;
    }

    public IEnumerable<PageField> GetAll()
    {
      return _context.PageFields;
    }

    public IEnumerable<PageField> GetAllByPageBlockId(long pageBlockId)
    {
      return _context.PageFields.Where(x=>x.PageBlockId==pageBlockId).OrderBy(x=>x.SortOrder).ThenBy(x=>x.Title);
    }


    public PageField GetById(long id)
    {
      return _context.PageFields.Find(id);
    }

    public PageField Create(PageField item)
    {

      _context.PageFields.Add(item);
      _context.SaveChanges();

      return item;
    }

    public void Update(PageField newitem)
    {
      var item = _context.PageFields.Find(newitem.Id);


      item.DataType = newitem.DataType;
      item.FieldId = newitem.FieldId;
      item.PageBlockId = newitem.PageBlockId;
      item.Title = newitem.Title;
      item.SortOrder = newitem.SortOrder;
      item.Value = newitem.Value;

      // update PageField properties

      _context.PageFields.Update(item);
      _context.SaveChanges();
    }

    public void Delete(long id)
    {
      var item = _context.PageFields.Find(id);
      if (item != null)
      {
        _context.PageFields.Remove(item);
        _context.SaveChanges();
      }
    }

  }
}
