using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Superjack.MultiSites.Api.Dtos
{
  public class BlockDto
  {
    public long Id { get; set; }
    public Guid Uuid { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateModified { get; set; }
    public string Title { get; set; }
    public long ParentId { get; set; }
    public string BlockType { get; set; }
    public bool CanHaveChildren { get; set; }

   public BlockFieldDto[] BlockFields { get; set; }

   


  }
}
