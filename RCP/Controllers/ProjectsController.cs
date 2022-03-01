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
    [Route("api/projects")]
    [ApiController]
    public class ProjectsController : CustomApiController
    {
      private readonly IAuthorizationService _authorizationService;
      private readonly IProjectLogic _projectLogic;

      public ProjectsController(IAuthorizationService authorizationService, IProjectLogic projectLogic)
      {
        _authorizationService = authorizationService;
        _projectLogic = projectLogic;
      }

      [HttpPost("")]
      public async Task<IActionResult> CreateProject([FromBody] ProjectCommandDto viewModel)
      {
        try
        {
          var access = await _authorizationService.HaveRights(UserName, (int)Enumerators.Enumerators.UserRoles.Administrator);
          if (access == false) return StatusCode(StatusCodes.Status401Unauthorized);

          var result = await _projectLogic.CreateProject(UserName, viewModel);

          return Ok(result);
        }
        catch (Exception e)
        {
          return StatusCode(StatusCodes.Status500InternalServerError);
        }
      }

      [HttpGet("active")]
      public async Task<IActionResult> ReadActiveProjects()
      {
        try
        {
          var result = await _projectLogic.ReadActiveProjects();

          return Ok(result);
        }
        catch (Exception e)
        {
          return StatusCode(StatusCodes.Status500InternalServerError);
        }
      }

      [HttpGet("{projectId}")]
      public async Task<IActionResult> ReadProject([FromRoute] int projectId)
      {
        try
        {
          var result = await _projectLogic.ReadProject(projectId);

          return Ok(result);
        }
        catch (Exception e)
        {
          return StatusCode(StatusCodes.Status500InternalServerError);
        }
      }

      [HttpGet("")]
      public async Task<IActionResult> ReadProjects()
      {
        try
        {
          var result = await _projectLogic.ReadProjects();

          return Ok(result);
        }
        catch (Exception e)
        {
          return StatusCode(StatusCodes.Status500InternalServerError);
        }
      }

      [HttpGet("user")]
      public async Task<IActionResult> ReadUserProjects()
      {
        try
        {
          var result = await _projectLogic.ReadUserProjects(UserName);

          return Ok(result);
        }
        catch (Exception e)
        {
          return StatusCode(StatusCodes.Status500InternalServerError);
        }
      }

    [HttpPut("{projectId}")]
      public async Task<IActionResult> UpdateProject([FromRoute] int projectId, [FromBody] ProjectCommandDto viewModel)
      {
        try
        {
          var access = await _authorizationService.HaveRights(UserName, (int)Enumerators.Enumerators.UserRoles.Administrator);
          if (access == false) return StatusCode(StatusCodes.Status401Unauthorized);

          var result = await _projectLogic.UpdateProject(projectId, UserName, viewModel);

          return Ok(result);
        }
        catch (Exception e)
        {
          return StatusCode(StatusCodes.Status500InternalServerError);
        }
      }

      [HttpDelete("{projectId}")]
      public async Task<IActionResult> DeleteProject([FromRoute] int projectId)
      {
        try
        {
          var access = await _authorizationService.HaveRights(UserName, (int)Enumerators.Enumerators.UserRoles.Administrator);
          if (access == false) return StatusCode(StatusCodes.Status401Unauthorized);

          await _projectLogic.DeleteProject(projectId);

          return Ok();
        }
        catch (Exception e)
        {
          return StatusCode(StatusCodes.Status500InternalServerError);
        }
      }
    }
}