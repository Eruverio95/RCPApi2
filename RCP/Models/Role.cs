using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RCP.Models
{
  public class Role
  {
    public Role()
    {
      UserProjectRoles = new HashSet<UserProjectRole>();
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<UserProjectRole> UserProjectRoles { get; set; }
  }
}
