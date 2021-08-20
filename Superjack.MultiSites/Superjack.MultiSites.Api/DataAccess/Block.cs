using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Superjack.MultiSites.Api.DataAccess
{
  public class Block
  {
    [Column("Id")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Required]
    public long Id { get; set; }

    [Column("Uuid")]
    [Required]
    public Guid Uuid { get; set; }

    [Column("DateCreated")]
    [Required]
    public DateTime DateCreated { get; set; }

    [Column("DateModified")]
    [Required]
    public DateTime DateModified { get; set; }

    [Column("Title")]
    [Required]
    public string Title { get; set; }

    [Column("ParentId")]
    public long ParentId { get; set; }

    [Column("BlockType")]
    [Required]
    public string BlockType { get; set; }

    [Column("CanHaveChildren")]
    [Required]
    public bool CanHaveChildren { get; set; }

   

   


  }
}
