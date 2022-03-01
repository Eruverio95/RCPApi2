using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RCP.ViewModels;

namespace RCP.Logic.Interfaces
{
  public interface IMeasurementLogic
  {
    Task CancelActiveMeasurement(int projectId, string userId);
    Task ContinueActiveMeasurement(int projectId, string userId);
    Task<ActiveMeasurementQueryDto> ReadCurrentActiveMeasurement(string userId);
    Task<MeasurementQueryDto> ReadMeasurement(int measurementId, string userId);
    Task<MeasurementQueryDto> ReadSuspendedMeasurement(int projectId, string userId);
    Task<ActiveMeasurementQueryDto> StartActiveMeasurement(int projectId, int activityId, string userId);
    Task<MeasurementQueryDto> StopActiveMeasurement(string userId);
    Task<MeasurementQueryDto> SuspendActiveMeasurement(string userId, bool temp = false);
  }
}