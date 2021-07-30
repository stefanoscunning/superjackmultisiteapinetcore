using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Superjack.MultiSites.Api.DataAccess
{
  public class User
  {
    [Column("Id")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Required]
    public long Id { get; set; }

    [Column("FirstName")]
    [Required]
    [StringLength(50)]
    public string FirstName { get; set; }

    [Column("Surname")]
    [Required]
    [StringLength(50)]
    public string Surname { get; set; }

    [Column("Username")]
    [Required]
    [StringLength(150)]
    public string Username { get; set; }

    [Column("PasswordHash")]
    [Required]
    public byte[] PasswordHash { get; set; }

    [Column("PasswordSalt")]
    [Required]
    public byte[] PasswordSalt { get; set; }

    [Column("DateCreated")]
    [Required]
    public DateTime DateCreated { get; set; }

    [Column("Status")]
    [Required]
    [StringLength(50)]
    public string Status { get; set; }
  }
}
