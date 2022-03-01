using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RCP.Models;

namespace RCP.Repository.Interfaces
{
  public interface IMeasurementQuestionnaireAnswerRepository
  {
    Task<MeasurementQuestionnaireAnswer> CreateMeasurementQuestionnaireAnswer(int measurementId, string answer);
  }
}
