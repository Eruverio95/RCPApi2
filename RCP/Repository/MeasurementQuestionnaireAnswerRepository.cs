using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RCP.Data;
using RCP.Models;
using RCP.Repository.Exceptions;
using RCP.Repository.Interfaces;

namespace RCP.Repository
{
  public class MeasurementQuestionnaireAnswerRepository : Repository<MeasurementQuestionnaireAnswer>, IMeasurementQuestionnaireAnswerRepository
  {
    public MeasurementQuestionnaireAnswerRepository(RCPDbContext context) : base(context)
    {
    }

    public async Task<MeasurementQuestionnaireAnswer> CreateMeasurementQuestionnaireAnswer(int measurementId, string answer)
    {
      var model = new MeasurementQuestionnaireAnswer() {MeasurementId = measurementId, Value = answer};
      var result = await _set.AddAsync(model);

      if (!await SaveChangesAsync())
      {
        throw new CreateException($"Could not create {nameof(MeasurementQuestionnaireAnswer)}");
      }

      return result.Entity;
    }
  }
}
