using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RCP.Helper;
using RCP.Logic.Interfaces;

namespace RCP.Controllers
{
    [Route("api/projects/{projectId}/measurements")]
    [ApiController]
    public class MeasurementsController : CustomApiController
    {
      private readonly IMeasurementLogic _measurementLogic;

      public MeasurementsController(IMeasurementLogic measurementLogic)
      {
        _measurementLogic = measurementLogic;
      }

      [HttpDelete("cancel")]
      public async Task<IActionResult> CancelActiveMeasurement([FromRoute] int projectId)
      {
        try
        {
          await _measurementLogic.CancelActiveMeasurement(projectId, UserName);

          return Ok();
        }
        catch (Exception e)
        {
          return StatusCode(StatusCodes.Status500InternalServerError);
        }
      }

      [HttpPost("continue")]
      public async Task<IActionResult> ContinueActiveMeasurement([FromRoute] int projectId)
      {
        try
        {
          await _measurementLogic.ContinueActiveMeasurement(projectId, UserName);

          return Ok();
        }
        catch (Exception e)
        {
          return StatusCode(StatusCodes.Status500InternalServerError);
        }
      }

      [HttpGet("")]
      public async Task<IActionResult> ReadActiveMeasurement([FromRoute] int projectId)
      {
        try
        {
          var result = await _measurementLogic.ReadCurrentActiveMeasurement(UserName);

          return Ok(result);
        }
        catch (Exception e)
        {
          return StatusCode(StatusCodes.Status500InternalServerError);
        }
      }

      [HttpGet("{measurementId}")]
      public async Task<IActionResult> ReadMeasurement([FromRoute] int projectId, [FromRoute] int measurementId)
      {
        try
        {
          var result = await _measurementLogic.ReadMeasurement(measurementId, UserName);

          return Ok(result);
        }
        catch (Exception e)
        {
          return StatusCode(StatusCodes.Status500InternalServerError);
        }
      }

      [HttpGet("stop")]
      public async Task<IActionResult> StopActiveMeasurement([FromRoute] int projectId)
      {
        try
        {
          var result = await _measurementLogic.StopActiveMeasurement(UserName);

          return Ok(result);
        }
        catch (Exception e)
        {
          return StatusCode(StatusCodes.Status500InternalServerError);
        }
      }

      [HttpGet("suspend")]
      public async Task<IActionResult> SuspendActiveMeasurement([FromRoute] int projectId)
      {
        try
        {
          var result = await _measurementLogic.SuspendActiveMeasurement(UserName);

          return Ok(result);
        }
        catch (Exception e)
        {
          return StatusCode(StatusCodes.Status500InternalServerError);
        }
      }
  }
}