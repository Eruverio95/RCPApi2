using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RCP.ViewModels
{
  public class QuestionnaireCommandDto
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public string QuestionValue { get; set; }
    public int QuestionType { get; set; }
    public bool QuestionRequired { get; set; }
    public int ProjectId { get; set; }
  }

  public class QuestionnaireQueryDto
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string QuestionValue { get; set; }
    public int QuestionType { get; set; }
    public bool QuestionRequired { get; set; }
    public int ProjectId { get; set; }
  }
}
