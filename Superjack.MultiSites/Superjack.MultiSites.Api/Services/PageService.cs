using LinqKit;
using Superjack.MultiSites.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Text.Json;
using System.Dynamic;

namespace Superjack.MultiSites.Api.Services
{
  public interface IPageService
  {
    IEnumerable<Page> GetAll();
    IEnumerable<Page> GetAllBySiteId(long siteId);

    IEnumerable<Page> Search(dynamic filters);
    IQueryable<Page> GetAllByQuery(dynamic filters);
    Page GetById(long id);
    Page Create(Page item);
    void Update(Page newitem);
    void Delete(long id);

  }
  public class PageService : IPageService
  {
    private AppDbContext _context;

    public PageService(AppDbContext context)
    {
      _context = context;
    }

    public IEnumerable<Page> GetAll()
    {
      return _context.Pages;
    }

    public IEnumerable<Page> GetAllBySiteId(long siteId)
    {

      
      
        var pages = _context.Pages.Where(x => x.SiteId == siteId && x.Published==true && x.Disabled==false && x.Binned==false && x.DateScheduledPublish!=null && x.DateScheduledPublish <= DateTime.Now && (x.DateScheduledExpiry==null || x.DateScheduledExpiry>DateTime.Now)).AsEnumerable().GroupBy(item => item.PageIdentifier)
                 .SelectMany(grouping => grouping.OrderByDescending(item => item.DateScheduledPublish).Take(1))
                 .OrderBy(item=>item.Level).ThenBy(item=>item.ParentPageIdentifier).ThenBy(item=>item.SortOrder)
                 .ToArray();


      return _context.Pages;
      //return _context.Pages.Where(x => x.SiteId == siteId && x.DatePublished <= DateTime.Now)
      //  .GroupBy(x => x.Route)
      //  .Select(g => g.OrderByDescending(x=>x.DatePublished).Take(1))
      //  .SelectMany(g => g).OrderBy(x => x.Level).ThenBy(x => x.ParentId).ThenBy(x => x.SortOrder);
        
    }

    public IEnumerable<Page> Search(dynamic filters)
    {

      IQueryable<Page> q = GetAllByQuery(filters);

      var pages = q.AsEnumerable().GroupBy(item => item.PageIdentifier)
               .SelectMany(grouping => grouping.OrderByDescending(item => item.DateScheduledPublish).Take(1))
               .OrderBy(item => item.Level).ThenBy(item => item.ParentPageIdentifier).ThenBy(item => item.SortOrder)
               .ToArray();


      return pages;
      //return _context.Pages.Where(x => x.SiteId == siteId && x.DatePublished <= DateTime.Now)
      //  .GroupBy(x => x.Route)
      //  .Select(g => g.OrderByDescending(x=>x.DatePublished).Take(1))
      //  .SelectMany(g => g).OrderBy(x => x.Level).ThenBy(x => x.ParentId).ThenBy(x => x.SortOrder);

    }

    public IQueryable<Page> GetAllByQuery(dynamic filters)
    {
      var predicate = PredicateBuilder.New<Page>();
      predicate = predicate.Start(x => x.Id > 0);

      if (IsPropertyExist(filters, "siteId"))
      {
        long siteId = Convert.ToInt64(filters.siteId);
        predicate = predicate.And(x => x.SiteId == siteId);
        
      }

      if (IsPropertyExist(filters, "pageIdentifier"))
      {
        string pageIdentifierQuery = filters.pageIdentifier.query;
        string pageIdentifierComparison = filters.pageIdentifier.comparison;
        switch (pageIdentifierComparison)
        {
          case "contains":
            predicate = predicate.And(x => x.PageIdentifier.Contains(pageIdentifierQuery));
            break;
          case "==":
            predicate = predicate.And(x => x.PageIdentifier == pageIdentifierQuery);
            break;
          case "!=":
            predicate = predicate.And(x => x.PageIdentifier != pageIdentifierQuery);
            break;
        }
      }

      if (IsPropertyExist(filters, "parentPageIdentifier"))
      {
        string pageIdentifierQuery = filters.parentPageIdentifier.query;
        string pageIdentifierComparison = filters.parentPageIdentifier.comparison;
        switch (pageIdentifierComparison)
        {
          case "contains":
            predicate = predicate.And(x => x.ParentPageIdentifier.Contains(pageIdentifierQuery));
            break;
          case "==":
            predicate = predicate.And(x => x.ParentPageIdentifier == pageIdentifierQuery);
            break;
          case "!=":
            predicate = predicate.And(x => x.ParentPageIdentifier != pageIdentifierQuery);
            break;
        }
      }

      if (IsPropertyExist(filters, "navigationTitle"))
      {
        string pageIdentifierQuery = filters.navigationTitle.query;
        string pageIdentifierComparison = filters.navigationTitle.comparison;
        switch (pageIdentifierComparison)
        {
          case "contains":
            predicate = predicate.And(x => x.NavigationTitle.Contains(pageIdentifierQuery));
            break;
          case "==":
            predicate = predicate.And(x => x.NavigationTitle == pageIdentifierQuery);
            break;
          case "!=":
            predicate = predicate.And(x => x.NavigationTitle != pageIdentifierQuery);
            break;
        }
      }

      if (IsPropertyExist(filters, "title"))
      {
        string pageIdentifierQuery = filters.title.query;
        string pageIdentifierComparison = filters.title.comparison;
        switch (pageIdentifierComparison)
        {
          case "contains":
            predicate = predicate.And(x => x.Title.Contains(pageIdentifierQuery));
            break;
          case "==":
            predicate = predicate.And(x => x.Title == pageIdentifierQuery);
            break;
          case "!=":
            predicate = predicate.And(x => x.Title != pageIdentifierQuery);
            break;
        }
      }

      if (IsPropertyExist(filters, "pageIdentifier"))
      {
        string pageIdentifierQuery = filters.pageIdentifier.query;
        string pageIdentifierComparison = filters.pageIdentifier.comparison;
        switch (pageIdentifierComparison)
        {
          case "contains":
            predicate = predicate.And(x => x.PageIdentifier.Contains(pageIdentifierQuery));
            break;
          case "==":
            predicate = predicate.And(x => x.PageIdentifier == pageIdentifierQuery);
            break;
          case "!=":
            predicate = predicate.And(x => x.PageIdentifier != pageIdentifierQuery);
            break;
        }
      }

      if (IsPropertyExist(filters, "dateCreated"))
      {
        DateTime dateQuery = Convert.ToDateTime(filters.dateCreated.query);
        string dateComparison = filters.dateCreated.comparison;
        switch (dateComparison)
        {
          case ">":
            predicate = predicate.And(x => x.DateCreated>dateQuery);
            break;
          case "<":
            predicate = predicate.And(x => x.DateCreated < dateQuery);
            break;
          
        }
      }

      if (IsPropertyExist(filters, "dateModified"))
      {
        DateTime dateQuery = Convert.ToDateTime(filters.dateModified.query);
        string dateComparison = filters.dateModified.comparison;
        switch (dateComparison)
        {
          case ">":
            predicate = predicate.And(x => x.DateModified > dateQuery);
            break;
          case "<":
            predicate = predicate.And(x => x.DateModified < dateQuery);
            break;

        }
      }

      if (IsPropertyExist(filters, "dateScheduledPublish"))
      {
        DateTime dateQuery = Convert.ToDateTime(filters.dateScheduledPublish.query);
        string dateComparison = filters.dateScheduledPublish.comparison;
        switch (dateComparison)
        {
          case ">":
            predicate = predicate.And(x => x.DateScheduledPublish > dateQuery);
            break;
          case "<":
            predicate = predicate.And(x => x.DateScheduledPublish < dateQuery);
            break;
          case "null":
            predicate = predicate.And(x => x.DateScheduledPublish == null);
            break;
          case "notnull":
            predicate = predicate.And(x => x.DateScheduledPublish != null);
            break;

        }
      }

      if (IsPropertyExist(filters, "dateScheduledExpiry"))
      {
        DateTime dateQuery = Convert.ToDateTime(filters.dateScheduledExpiry.query);
        string dateComparison = filters.dateScheduledExpiry.comparison;
        switch (dateComparison)
        {
          case ">":
            predicate = predicate.And(x => x.DateScheduledExpiry > dateQuery);
            break;
          case "<":
            predicate = predicate.And(x => x.DateScheduledExpiry < dateQuery);
            break;
          case "null":
            predicate = predicate.And(x => x.DateScheduledExpiry == null);
            break;
          case "notnull":
            predicate = predicate.And(x => x.DateScheduledExpiry != null);
            break;
          case "current":
            predicate = predicate.And(x => x.DateScheduledExpiry == null || x.DateScheduledExpiry>dateQuery);
            break;

        }
      }

      if (IsPropertyExist(filters, "draft"))
      {
        if (filters.draft)
        {
          predicate = predicate.And(x => x.Draft == true);
        }
        else
        {
          predicate = predicate.And(x => x.Draft == false);
        }
      }
      if (IsPropertyExist(filters, "published"))
      {
        if (filters.published)
        {
          predicate = predicate.And(x => x.Published == true);
        }
        else
        {
          predicate = predicate.And(x => x.Published == false);
        }
      }
      if (IsPropertyExist(filters, "disabled"))
      {
        if (filters.disabled)
        {
          predicate = predicate.And(x => x.Disabled == true);
        }
        else
        {
          predicate = predicate.And(x => x.Disabled == false);
        }
      }
      if (IsPropertyExist(filters, "binned"))
      {
        if (filters.binned)
        {
          predicate = predicate.And(x => x.Binned == true);
        }
        else
        {
          predicate = predicate.And(x => x.Binned == false);
        }
      }

      if (IsPropertyExist(filters, "level"))
      {
        int level = Convert.ToInt32(filters.level);
        predicate = predicate.And(x => x.Level == level);
      }

      return _context.Pages.AsExpandable().Where(predicate);

    }

    public static bool IsPropertyExist(dynamic settings, string name)
    {
      if (settings is ExpandoObject)
        return ((IDictionary<string, object>)settings).ContainsKey(name);

      return settings.GetType().GetProperty(name) != null;
    }



    public Page GetById(long id)
    {
      return _context.Pages.Find(id);
    }

    public Page Create(Page item)
    {

      _context.Pages.Add(item);
      _context.SaveChanges();

      return item;
    }

    public void Update(Page newitem)
    {
      var item = _context.Pages.Find(newitem.Id);

      item.PageIdentifier = newitem.PageIdentifier;
      item.DateCreated = newitem.DateCreated;
      item.DateModified = newitem.DateModified;
      item.DateScheduledPublish = newitem.DateScheduledPublish;
      item.DateScheduledExpiry = newitem.DateScheduledExpiry;
      item.MetaDescription = newitem.MetaDescription;
      item.MetaKeywords = newitem.MetaKeywords;
      item.NavigationTitle = newitem.NavigationTitle;
      item.PageTypeId = newitem.PageTypeId;
      item.ParentPageIdentifier = newitem.ParentPageIdentifier;
      item.Level = newitem.Level;
      item.Route = newitem.Route;
      item.SiteId = newitem.SiteId;
      item.SortOrder = newitem.SortOrder;
      item.Title = newitem.Title;
      item.Draft = newitem.Draft;
      item.Published = newitem.Published;
      item.Disabled = newitem.Disabled;
      item.Binned = newitem.Binned;

      // update Page properties

      _context.Pages.Update(item);
      _context.SaveChanges();
    }

    public void Delete(long id)
    {
      var item = _context.Pages.Find(id);
      if (item != null)
      {
        _context.Pages.Remove(item);
        _context.SaveChanges();
      }
    }

  }
}
