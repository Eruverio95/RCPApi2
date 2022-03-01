using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RCP.ViewModels
{
  public class ProjectCommandDto
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime DateTimeStart { get; set; }
    public DateTime DateTimeEnd { get; set; }
  }

  public class ProjectQueryDto
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime DateTimeStart { get; set; }
    public DateTime DateTimeEnd { get; set; }
  }
}
