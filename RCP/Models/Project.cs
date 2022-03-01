using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RCP.Models
{
  public class Project

  {
    public Project()
    {
      Activities = new HashSet<Activity>();
      Questionnaires = new HashSet<Questionnaire>();
      UserProjectRoles = new HashSet<UserProjectRole>();
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime DateTimeStart { get; set; }
    public DateTime DateTimeEnd { get; set; }
    public ICollection<Activity> Activities { get; set; }
    public ICollection<Questionnaire> Questionnaires { get; set; }
    public ICollection<UserProjectRole> UserProjectRoles { get; set; }
  }
}