﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Superjack.MultiSites.Api.Dtos
{
  public class PageBlockDto
  {
    public long Id { get; set; }
    public long PageId { get; set; }

    public long BlockId { get; set; }

    public long ParentId { get; set; }

    public long SortOrder { get; set; }


   
  }
}
