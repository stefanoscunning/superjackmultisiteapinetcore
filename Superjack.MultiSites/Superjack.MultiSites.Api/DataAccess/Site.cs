using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Superjack.MultiSites.Api.DataAccess
{
  public class Site
  {
    [Column("Id")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Required]
    public long Id { get; set; }

    [Column("Uuid")]
    [Required]
    public Guid Uuid { get; set; }

    [Column("Protocol")]
    [Required]
    [StringLength(5)]
    public string Protocol { get; set; }

    [Column("DomainName")]
    [Required]
    [StringLength(150)]
    public string DomainName { get; set; }

    [Column("Culture")]
    [Required]
    [StringLength(10)]
    public string Culture { get; set; }

   
  }
}
