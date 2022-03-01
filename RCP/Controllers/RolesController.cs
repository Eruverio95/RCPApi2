using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RCP.Helper;
using RCP.Logic.Interfaces;
using RCP.ViewModels;

namespace RCP.Controllers
{
  [Route("api/roles")]
  [ApiController]
  public class RolesController : CustomApiController
  {
    private readonly IAuthorizationService _authorizationService;
    private readonly IRoleLogic _roleLogic;
    private readonly IUserLogic _userLogic;

    public RolesController(IAuthorizationService authorizationService, IRoleLogic roleLogic, IUserLogic userLogic)
    {
      _authorizationService = authorizationService;
      _roleLogic = roleLogic;
      _userLogic = userLogic;
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateRole([FromBody] RoleCommandDto viewModel)
    {
      try
      {
        var access = await _authorizationService.HaveRights(UserName, (int)Enumerators.Enumerators.UserRoles.Administrator);
        if (access == false) return StatusCode(StatusCodes.Status401Unauthorized);

        var result = await _roleLogic.CreateRole(viewModel);

        return Ok(result);
      }
      catch (Exception e)
      {
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    [HttpGet("")]
    public async Task<IActionResult> ReadRoles()
    {
      try
      {
        var result = await _roleLogic.ReadRoles();

        return Ok(result);
      }
      catch (Exception e)
      {
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    [HttpGet("{roleId}")]
    public async Task<IActionResult> ReadRole([FromRoute] int roleId)
    {
      try
      {
        var result = await _roleLogic.ReadRole(roleId);

        return Ok(result);
      }
      catch (Exception e)
      {
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    [HttpGet("project/{projectId}")]
    public async Task<IActionResult> ReadUserRoles([FromRoute] int projectId)
    {
      try
      {
        var result = await _userLogic.ReadUserProjectRoles(projectId, UserName);

        return Ok(result);
      }
      catch (Exception e)
      {
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    [HttpPut("{roleId}")]
    public async Task<IActionResult> UpdateRole([FromRoute] int roleId, [FromBody] RoleCommandDto viewModel)
    {
      try
      {
        var access = await _authorizationService.HaveRights(UserName, (int)Enumerators.Enumerators.UserRoles.Administrator);
        if (access == false) return StatusCode(StatusCodes.Status401Unauthorized);

        var result = await _roleLogic.UpdateRole(roleId, viewModel);

        return Ok(result);
      }
      catch (Exception e)
      {
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    [HttpDelete("{roleId}")]
    public async Task<IActionResult> DeleteRole([FromRoute] int roleId)
    {
      try
      {
        var access = await _authorizationService.HaveRights(UserName, (int)Enumerators.Enumerators.UserRoles.Administrator);
        if (access == false) return StatusCode(StatusCodes.Status401Unauthorized);

        await _roleLogic.DeleteRole(roleId);

        return Ok();
      }
      catch (Exception e)
      {
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }
  }
}