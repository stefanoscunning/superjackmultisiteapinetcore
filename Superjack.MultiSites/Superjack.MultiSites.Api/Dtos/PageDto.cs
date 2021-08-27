using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Superjack.MultiSites.Api.Dtos
{
  public class PageDto
  {
    public long Id { get; set; }
    public Guid Uuid { get; set; }
    public string PageIdentifier { get; set; }
    public DateTime DateCreated { get; set; }

    public DateTime DateModified { get; set; }

    public string MetaDescription { get; set; }

    public string MetaKeywords { get; set; }

    public string NavigationTitle { get; set; }

    public string PageTypeId { get; set; }

    public string ParentPageIdentifier { get; set; }
    public int Level { get; set; }

    public DateTime? DateScheduledPublish { get; set; }

    public DateTime? DateScheduledExpiry { get; set; }

    public string Route { get; set; }

    public long SiteId { get; set; }

    public long SortOrder { get; set; }

    public string Title { get; set; }

    public bool Draft { get; set; }
    public bool Published { get; set; }
    public bool Disabled { get; set; }
    public bool Binned { get; set; }

    public PageDto[] Versions { get; set; }
    public PageDto[] Children { get; set; }

  }
}
