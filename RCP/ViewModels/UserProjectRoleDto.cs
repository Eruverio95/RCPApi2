using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RCP.ViewModels
{
  public class UserProjectRoleCommandDto
  {
    public string UserId { get; set; }
    public int ProjectId { get; set; }
    public int RoleId { get; set; }
  }

  public class UserProjectRoleQueryDto
  {
    public int Id { get; set; }
    public string UserId { get; set; }
    public int ProjectId { get; set; }
    public int RoleId { get; set; }
  }
}
