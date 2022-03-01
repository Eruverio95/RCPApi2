using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RCP.Helper;
using RCP.Logic.Interfaces;
using RCP.ViewModels;

namespace RCP.Controllers
{
    [Route("api/projects/{projectId}/activities")]
    [ApiController]
    public class ActivitiesController : CustomApiController
    {
      private readonly IAuthorizationService _authorizationService;
      private readonly IActivityLogic _activityLogic;
      private readonly IMeasurementLogic _measurementLogic;

      public ActivitiesController(IAuthorizationService authorizationService, IActivityLogic activityLogic, IMeasurementLogic measurementLogic)
      {
        _authorizationService = authorizationService;
        _activityLogic = activityLogic;
        _measurementLogic = measurementLogic;
      }

      [HttpPost("")]
      public async Task<IActionResult> CreateActivity([FromRoute] int projectId, [FromBody] ActivityCommandDto viewModel)
      {
        try
        {
          var access = await _authorizationService.HaveRights(UserName, (int) Enumerators.Enumerators.UserRoles.Administrator);
          if (access == false) return StatusCode(StatusCodes.Status401Unauthorized);

          var result = await _activityLogic.CreateActivity(projectId, UserName, viewModel);

          return Ok(result);
        }
        catch (Exception e)
        {
          return StatusCode(StatusCodes.Status500InternalServerError);
        }
      }

      [HttpGet("{activityId}")]
      public async Task<IActionResult> ReadActivity([FromRoute] int projectId, [FromRoute] int activityId)
      {
        try
        {
          var result = await _activityLogic.ReadActivity(projectId, activityId, UserName);

          return Ok(result);
        }
        catch (Exception e)
        {
          return StatusCode(StatusCodes.Status500InternalServerError);
        }
      }

      [HttpGet("")]
      public async Task<IActionResult> ReadActivities([FromRoute] int projectId)
      {
        try
        {
          var result = await _activityLogic.ReadActivities(projectId, UserName);

          return Ok(result);
        }
        catch (Exception e)
        {
          return StatusCode(StatusCodes.Status500InternalServerError);
        }
      }

      [HttpPut("{activityId}")]
      public async Task<IActionResult> UpdateActivity([FromRoute] int projectId, [FromRoute] int activityId, [FromBody] ActivityCommandDto viewModel)
      {
        try
        {
          var access = await _authorizationService.HaveRights(UserName, (int)Enumerators.Enumerators.UserRoles.Administrator);
          if (access == false) return StatusCode(StatusCodes.Status401Unauthorized);

          var result = await _activityLogic.UpdateActivity(projectId, activityId, UserName, viewModel);

          return Ok(result);
        }
        catch (Exception e)
        {
          return StatusCode(StatusCodes.Status500InternalServerError);
        }
      }

      [HttpDelete("{activityId}")]
      public async Task<IActionResult> DeleteActivity([FromRoute] int projectId, [FromRoute] int activityId)
      {
        try
        {
          var access = await _authorizationService.HaveRights(UserName, (int)Enumerators.Enumerators.UserRoles.Administrator);
          if (access == false) return StatusCode(StatusCodes.Status401Unauthorized);

          await _activityLogic.DeleteActivity(projectId, activityId);

          return Ok();
        }
        catch (Exception e)
        {
          return StatusCode(StatusCodes.Status500InternalServerError);
        }
      }

      [HttpGet("{activityId}/start")]
      public async Task<IActionResult> StartActivity([FromRoute] int projectId, [FromRoute] int activityId)
      {
        try
        {
          var result = await _measurementLogic.StartActiveMeasurement(projectId, activityId, UserName);

          return Ok(result);
        }
        catch (Exception e)
        {
          return StatusCode(StatusCodes.Status500InternalServerError);
        }
      }

      [HttpGet("search")]
      public async Task<IActionResult> SearchActivities([FromRoute] int projectId, [FromQuery] string query)
      {
        try
        {
          var result = await _activityLogic.SearchActivities(projectId, query);

          return Ok(result);
        }
        catch (Exception e)
        {
          return StatusCode(StatusCodes.Status500InternalServerError);
        }
      }
  }
}