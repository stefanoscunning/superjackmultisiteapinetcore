using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Superjack.MultiSites.Api.Dtos
{
  public class PageFieldDto
  {
    public long Id { get; set; }
    public Guid Uuid { get; set; }

    public long PageBlockId { get; set; }

    public long? FieldId { get; set; }
    public string Title { get; set; }

    public string DataType { get; set; }

    public long SortOrder { get; set; }

    public string Value { get; set; }
    public BlockFieldDto? BlockField { get; set; }
  }
}

