using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RCP.ViewModels
{
  public class ActivityCommandDto
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public int ProjectId { get; set; }
    public int QuestionnaireId { get; set; }
  }

  public class ActivityQueryDto
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int ProjectId { get; set; }
    public int QuestionnaireId { get; set; }
  }
}
