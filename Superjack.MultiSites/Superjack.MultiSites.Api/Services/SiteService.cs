using Microsoft.EntityFrameworkCore;
using Superjack.MultiSites.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Superjack.MultiSites.Api.Services
{
  public interface ISiteService
  {

    Task<IEnumerable<Site>> GetAllAsync();
    IEnumerable<Site> GetAll();
    Site GetById(long id);
    Site GetByUuid(string uuid);
    Site Create(Site item);
    void Update(Site newitem);
    void Delete(long id);

  }
  public class SiteService : ISiteService
  {
    private AppDbContext _context;

    public SiteService(AppDbContext context)
    {
      _context = context;
    }

    public async Task<IEnumerable<Site>> GetAllAsync()
    {
      return await _context.Sites.OrderBy(x => x.DomainName).ThenBy(x => x.Culture).ToListAsync();
    }

    public IEnumerable<Site> GetAll()
    {
      return _context.Sites.OrderBy(x=>x.DomainName).ThenBy(x=>x.Culture);
    }


    public Site GetById(long id)
    {
      return _context.Sites.Find(id);
    }

    public Site GetByUuid(string uuid)
    {
      return _context.Sites.Where(x=>x.Uuid==Guid.Parse(uuid)).FirstOrDefault();
    }

    public Site Create(Site item)
    {

      _context.Sites.Add(item);
      _context.SaveChanges();

      return item;
    }

    public void Update(Site newitem)
    {
      var item = _context.Sites.Find(newitem.Id);


      item.Culture = newitem.Culture;
      item.DomainName = newitem.DomainName;
      item.Protocol = newitem.Protocol;

      // update Site properties

      _context.Sites.Update(item);
      _context.SaveChanges();
    }

    public void Delete(long id)
    {
      var item = _context.Sites.Find(id);
      if (item != null)
      {
        _context.Sites.Remove(item);
        _context.SaveChanges();
      }
    }

  }
}
