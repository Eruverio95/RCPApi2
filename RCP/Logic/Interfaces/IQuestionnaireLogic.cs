using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RCP.ViewModels;

namespace RCP.Logic.Interfaces
{
  public interface IQuestionnaireLogic
  {
    Task<QuestionnaireQueryDto> ReadCurrentQuestionnaire(int projectId, int questionnaireId, string userId);

    Task<MeasurementQuestionnaireAnswerQueryDto> SaveCurrentQuestionnaireAnswer(int projectId, string userId,
      MeasurementQuestionnaireAnswerCommandDto viewModel);
  }
}
