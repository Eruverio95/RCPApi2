using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RCP.ViewModels
{
  public class RoleCommandDto
  {
    public string Name { get; set; }
  }

  public class RoleQueryDto
  {
    public int Id { get; set; }
    public string Name { get; set; }
  }
}
