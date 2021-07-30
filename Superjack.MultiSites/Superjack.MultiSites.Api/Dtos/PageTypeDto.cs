using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Superjack.MultiSites.Api.Dtos
{
  public class PageTypeDto
  {
    public string Id { get; set; }

    public string Body { get; set; }

    public DateTime DateCreated { get; set; }

   

  }
}
