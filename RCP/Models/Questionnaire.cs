using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RCP.Models
{
  public class Questionnaire
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string QuestionValue { get; set; }
    public Enumerators.Enumerators.QuestionType  QuestionType { get; set; }
    public bool QuestionRequired { get; set; }
    public int ProjectId { get; set; }
    public Project Project { get; set; }
  }
}