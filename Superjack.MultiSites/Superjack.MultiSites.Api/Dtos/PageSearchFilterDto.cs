using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Superjack.MultiSites.Api.Dtos
{
  public class PageSearchFilterDto
  {
    public PageSearchComparisonQueryDto? PageIdentifier {get; set;}
    public PageSearchComparisonQueryDto? ParentPageIdentifier { get; set; }
    public int? Level { get; set; }
    public PageSearchComparisonQueryDto? DateScheduledPublished { get; set; }
    public PageSearchComparisonQueryDto? DateScheduledExpiry { get; set; }
    public long? SiteId { get; set; }
    public bool? Draft { get; set; }
    public bool? Published { get; set; }
    public bool? Disabled { get; set; }
    public bool? Binned { get; set; }


  }
}
