using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RCP.Data;
using RCP.Models;
using RCP.Repository.Exceptions;
using RCP.Repository.Interfaces;

namespace RCP.Repository
{
  public class QuestionnaireRepository : Repository<Questionnaire>, IQuestionnaireRepository
  {
    public QuestionnaireRepository(RCPDbContext context) : base(context)
    {
    }

    public async Task<Questionnaire> ReadQuestionnaire(int projectId, int questionnaireId)
    {
      var result = await AsQueryable().SingleOrDefaultAsync(x => x.ProjectId == projectId && x.Id == questionnaireId);

      if (result == null)
      {
        throw new NotFoundException($"Could not found {nameof(Questionnaire)}");
      }

      return result;
    }
  }
}
