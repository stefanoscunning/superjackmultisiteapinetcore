using Superjack.MultiSites.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Superjack.MultiSites.Api.Services
{
  public interface IPageTypeService
  {
    IEnumerable<PageType> GetAll();
    PageType GetById(long id);
    PageType Create(PageType item);
    void Update(PageType newitem);
    void Delete(long id);

  }
  public class PageTypeService : IPageTypeService
  {
    private AppDbContext _context;

    public PageTypeService(AppDbContext context)
    {
      _context = context;
    }

    public IEnumerable<PageType> GetAll()
    {
      return _context.PageTypes;
    }


    public PageType GetById(long id)
    {
      return _context.PageTypes.Find(id);
    }

    public PageType Create(PageType item)
    {

      _context.PageTypes.Add(item);
      _context.SaveChanges();

      return item;
    }

    public void Update(PageType newitem)
    {
      var item = _context.PageTypes.Find(newitem.Id);


      item.Body = newitem.Body;
      item.DateCreated = newitem.DateCreated;
      
      // update PageType properties

      _context.PageTypes.Update(item);
      _context.SaveChanges();
    }

    public void Delete(long id)
    {
      var item = _context.PageTypes.Find(id);
      if (item != null)
      {
        _context.PageTypes.Remove(item);
        _context.SaveChanges();
      }
    }

  }
}
