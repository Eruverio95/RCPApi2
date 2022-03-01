using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Pages.Internal.Account.Manage;
using Microsoft.AspNetCore.Mvc;
using RCP.Helper;
using RCP.Logic.Interfaces;
using RCP.ViewModels;

namespace RCP.Controllers
{
    [Route("api/projects/{projectId}/questionnaires")]
    [ApiController]
    public class QuestionnairesController : CustomApiController
    {
      private readonly IQuestionnaireLogic _questionnaireLogic;

      public QuestionnairesController(IQuestionnaireLogic questionnaireLogic)
      {
        _questionnaireLogic = questionnaireLogic;
      }

      [HttpPost("")]
      public async Task<IActionResult> AnswerActiveQuestionnaire([FromRoute] int projectId, [FromBody] MeasurementQuestionnaireAnswerCommandDto viewModel)
      {
        try
        {
          var result = await _questionnaireLogic.SaveCurrentQuestionnaireAnswer(projectId, UserName, viewModel);

          return Ok(result);
        }
        catch (Exception e)
        {
          return StatusCode(StatusCodes.Status500InternalServerError);
        }
      }

      [HttpGet("{questionnaireId}")]
      public async Task<IActionResult> ReadActiveQuestionnaire([FromRoute] int projectId, [FromRoute] int questionnaireId)
      {
        try
        {
          var result = await _questionnaireLogic.ReadCurrentQuestionnaire(projectId, questionnaireId, UserName);

          return Ok(result);
        }
        catch (Exception e)
        {
          return StatusCode(StatusCodes.Status500InternalServerError);
        }
      }
    }
}