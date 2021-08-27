using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Superjack.MultiSites.Api.DataAccess
{
  public class PageBlock
  {
    [Column("Id")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Required]
    public long Id { get; set; }

    [Column("Uuid")]
    [Required]
    public Guid Uuid { get; set; }

    [Column("PageId")]
    [Required]
    public long PageId { get; set; }

    [Column("BlockId")]
    [Required]
    public long BlockId { get; set; }

    [Column("ParentId")]
    public long ParentId { get; set; }

    [Column("SortOrder")]
    [Required]
    public long SortOrder { get; set; }

    [Column("Level")]
    public int Level { get; set; }



  }
}
