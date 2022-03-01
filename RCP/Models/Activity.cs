using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RCP.Models
{
  public class Activity
  {
    public Activity()
    {
      Questionnaires = new HashSet<Questionnaire>();
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int ProjectId { get; set; }
    public Project Project { get; set; }
    public int QuestionnaireId { get; set; }
    public Questionnaire Questionnaire { get; set; }
    public ICollection<Questionnaire> Questionnaires { get; set; }
  }
}
