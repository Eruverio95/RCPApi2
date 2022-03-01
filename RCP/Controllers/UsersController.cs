using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using RCP.Helper;
using RCP.Logic.Interfaces;
using RCP.ViewModels;

namespace RCP.Controllers
{
  [Route("api/users")]
  [ApiController]
  public class UsersController : CustomApiController
  {
    private readonly IAuthorizationService _authorizationService;
    private readonly IMeasurementLogic _measurementLogic;
    private readonly IProjectLogic _projectLogic;
    private readonly IUserLogic _userLogic;

    public UsersController(IAuthorizationService authorizationService, IMeasurementLogic measurementLogic, IProjectLogic projectLogic, IUserLogic userLogic)
    {
      _authorizationService = authorizationService;
      _measurementLogic = measurementLogic;
      _projectLogic = projectLogic;
      _userLogic = userLogic;
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateUser([FromBody] UserCommandDto viewModel)
    {
      try
      {
        var access = await _authorizationService.HaveRights(UserName, (int)Enumerators.Enumerators.UserRoles.Administrator);
        if (access == false) return StatusCode(StatusCodes.Status401Unauthorized);

        var result = await _userLogic.CreateUser(viewModel);

        return Ok(result);
      }
      catch (Exception e)
      {
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    [HttpGet("")]
    public async Task<IActionResult> ReadCurrentUser()
    {
      try
      {
        var result = await _userLogic.ReadUser(UserName);

        return Ok(result);
      }
      catch (Exception e)
      {
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> ReadUser([FromRoute] string userId)
    {
      try
      {
        var access = await _authorizationService.HaveRights(UserName, (int)Enumerators.Enumerators.UserRoles.Administrator);
        if (access == false) return StatusCode(StatusCodes.Status401Unauthorized);

        var result = await _userLogic.ReadUser(userId);

        return Ok(result);
      }
      catch (Exception e)
      {
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    [HttpGet("role/{roleId}")]
    public async Task<IActionResult> ReadUsersByRole([FromRoute] int roleId)
    {
      try
      {
        var access = await _authorizationService.HaveRights(UserName, (int)Enumerators.Enumerators.UserRoles.Administrator);
        if (access == false) return StatusCode(StatusCodes.Status401Unauthorized);

        var result = await _userLogic.ReadUsersByRole(roleId);

        return Ok(result);
      }
      catch (Exception e)
      {
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    [HttpGet("project/{projectId}")]
    public async Task<IActionResult> ReadUsersForProject([FromRoute] int projectId)
    {
      try
      {
        var access = await _authorizationService.HaveRights(UserName, (int)Enumerators.Enumerators.UserRoles.Administrator);
        if (access == false) return StatusCode(StatusCodes.Status401Unauthorized);

        var result = await _userLogic.ReadUsers(projectId, null);

        return Ok(result);
      }
      catch (Exception e)
      {
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    [HttpPut("{userId}")]
    public async Task<IActionResult> UpdateUser([FromRoute] string userId, [FromBody] UserCommandDto viewModel)
    {
      try
      {
        var access = await _authorizationService.HaveRights(UserName, (int)Enumerators.Enumerators.UserRoles.Administrator);
        if (access == false) return StatusCode(StatusCodes.Status401Unauthorized);

        var result = await _userLogic.UpdateUser(userId, viewModel);

        return Ok(result);
      }
      catch (Exception e)
      {
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    [HttpGet("project/{projectId}/exists")]
    public async Task<IActionResult> UserExistsInProject([FromRoute] int projectId)
    {
      try
      {
        var result = await _userLogic.UserExistsInProject(projectId, UserName);

        return Ok(result);
      }
      catch (Exception e)
      {
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    [HttpDelete("{userId}")]
    public async Task<IActionResult> DeleteUser([FromRoute] string userId)
    {
      try
      {
        var access = await _authorizationService.HaveRights(UserName, (int)Enumerators.Enumerators.UserRoles.Administrator);
        if (access == false) return StatusCode(StatusCodes.Status401Unauthorized);

        await _userLogic.DeleteUser(userId);

        return Ok();
      }
      catch (Exception e)
      {
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    [HttpDelete("{userId}/project/{projectId}/role/{roleId}")]
    public async Task<IActionResult> DeleteUserProjectRole([FromRoute] string userId, [FromRoute] int projectId, [FromRoute] int roleId)
    {
      try
      {
        var access = await _authorizationService.HaveRights(UserName, (int)Enumerators.Enumerators.UserRoles.Administrator);
        if (access == false) return StatusCode(StatusCodes.Status401Unauthorized);

        await _userLogic.DeleteUserProjectRole(projectId, userId, roleId);

        return Ok();
      }
      catch (Exception e)
      {
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    [HttpPost("{userId}/project/{projectId}/role/{roleId}")]
    public async Task<IActionResult> AddUserProjectRole([FromRoute] string userId, [FromRoute] int projectId, [FromRoute] int roleId)
    {
      try
      {
        var access = await _authorizationService.HaveRights(UserName, (int)Enumerators.Enumerators.UserRoles.Administrator);
        if (access == false) return StatusCode(StatusCodes.Status401Unauthorized);

        var result = await _userLogic.CreateUserProjectRole(projectId, userId, roleId);

        return Ok(result);
      }
      catch (Exception e)
      {
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    [HttpPost("{userId}/project/{projectId}")]
    public async Task<IActionResult> AddUserToProject([FromRoute] string userId, [FromRoute] int projectId)
    {
      try
      {
        var access = await _authorizationService.HaveRights(UserName, (int)Enumerators.Enumerators.UserRoles.Administrator);
        if (access == false) return StatusCode(StatusCodes.Status401Unauthorized);

        var result = await _userLogic.AddUserToProject(projectId, userId);

        return Ok(result);
      }
      catch (Exception e)
      {
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    [HttpGet("search")]
    public async Task<IActionResult> SearchUsers([FromQuery] string query)
    {
      try
      {
        var access = await _authorizationService.HaveRights(UserName, (int)Enumerators.Enumerators.UserRoles.Administrator);
        if (access == false) return StatusCode(StatusCodes.Status401Unauthorized);

        var result = await _userLogic.SearchUsers(query);

        return Ok(result);
      }
      catch (Exception e)
      {
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    [HttpGet("project/{projectId}/search")]
    public async Task<IActionResult> SearchUsers([FromRoute] int projectId, [FromQuery] string query)
    {
      try
      {
        var access = await _authorizationService.HaveRights(UserName, (int)Enumerators.Enumerators.UserRoles.Administrator);
        if (access == false) return StatusCode(StatusCodes.Status401Unauthorized);

        var result = await _userLogic.SearchUsersInProject(projectId, query);

        return Ok(result);
      }
      catch (Exception e)
      {
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    [HttpGet("start")]
    public async Task<IActionResult> Start()
    {
      try
      {
        var info = await _userLogic.Start(UserName);

        var userProjects = await _projectLogic.ReadUserProjects(UserName);
        var activeMeasurement = await _measurementLogic.ReadCurrentActiveMeasurement(UserName);
        var selected = await _projectLogic.ReadUserActiveProject(UserName);
        var userRoles = await _userLogic.ReadUserProjectRoles(selected.Id, UserName);

        return Ok(new { Info = info, UserProjects = userProjects, ActiveMeasurement = activeMeasurement, SelectedProject = selected, UserProjectRoles = userRoles});
      }
      catch (Exception e)
      {
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }
  }
}