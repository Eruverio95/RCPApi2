using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RCP.Models
{
  public class UserProjectRole
  {
    public int Id { get; set; }
    public string UserId { get; set; }
    public User User { get; set; }
    public int ProjectId { get; set; }
    public Project Project { get; set; }
    public int RoleId { get; set; }
    public Role Role { get; set; }
  }
}
