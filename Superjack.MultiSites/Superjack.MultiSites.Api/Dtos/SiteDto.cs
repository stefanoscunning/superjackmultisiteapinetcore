using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Superjack.MultiSites.Api.Dtos
{
  public class SiteDto
  {
    public long Id { get; set; }

    public Guid Uuid { get; set; }

    public string Protocol { get; set; }

    public string DomainName { get; set; }

    public string Culture { get; set; }

   
  }
}
