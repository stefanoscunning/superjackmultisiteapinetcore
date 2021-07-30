using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Superjack.MultiSites.Api.DataAccess
{
  public class PageType
  {
    [Column("Id")]
    [Key]
    [Required]
    [StringLength(50)]
    public string Id { get; set; }

    [Column("Body")]
    [Required]
    public string Body { get; set; }

    [Column("DateCreated")]
    [Required]
    public DateTime DateCreated { get; set; }

   

  }
}
