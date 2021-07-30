using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Superjack.MultiSites.Api.Dtos
{
  public class UserDto
  {
    public long Id { get; set; }

    public string FirstName { get; set; }

    public string Surname { get; set; }

    public string Username { get; set; }

    public DateTime DateCreated { get; set; }

    public string Status { get; set; }
    public string Password { get; set; }
  }
}
