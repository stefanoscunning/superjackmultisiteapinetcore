using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Superjack.MultiSites.Api.DataAccess
{
  public class Page
  {
    [Column("Id")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Required]
    public long Id { get; set; }

    [Column("Uuid")]
    [Required]
    public Guid Uuid { get; set; }

    [Column("PageIdentifier")]
    [Required]
    public string PageIdentifier { get; set; }

    [Column("DateCreated")]
    [Required]
    public DateTime DateCreated { get; set; }

    [Column("DateModified")]
    [Required]
    public DateTime DateModified { get; set; }

    [Column("MetaDescription")]
    public string MetaDescription { get; set; }

    [Column("MetaKeywords")]
    public string MetaKeywords { get; set; }

    [Column("NavigationTitle")]
    public string NavigationTitle { get; set; }

    [Column("PageTypeId")]
    [Required]
    [StringLength(50)]
    public string PageTypeId { get; set; }

    [Column("ParentPageIdentifier")]
    public string ParentPageIdentifier { get; set; }

    [Column("Level")]
    public int Level { get; set; }

    [Column("DateScheduledPublish")]
    public DateTime? DateScheduledPublish { get; set; }

    [Column("DateScheduledExpiry")]
    public DateTime? DateScheduledExpiry { get; set; }



    [Column("Route")]
    [Required]
    public string Route { get; set; }

    [Column("SiteId")]
    [Required]
    public long SiteId { get; set; }

    [Column("SortOrder")]
    [Required]
    public long SortOrder { get; set; }

    [Column("Title")]
    [Required]
    public string Title { get; set; }

    [Column("Draft")]
    [Required]
    public bool Draft { get; set; }

    [Column("Published")]
    [Required]
    public bool Published { get; set; }

    [Column("Disabled")]
    [Required]
    public bool Disabled { get; set; }

    [Column("Binned")]
    [Required]
    public bool Binned { get; set; }



  }
}
