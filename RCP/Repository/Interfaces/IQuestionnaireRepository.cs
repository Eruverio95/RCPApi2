using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RCP.Models;

namespace RCP.Repository.Interfaces
{
  public interface IQuestionnaireRepository
  {
    Task<Questionnaire> ReadQuestionnaire(int projectId, int questionnaireId);
  }
}
