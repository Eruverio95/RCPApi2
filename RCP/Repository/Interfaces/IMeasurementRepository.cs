using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RCP.Models;

namespace RCP.Repository.Interfaces
{
  public interface IMeasurementRepository
  {
    Task<Measurement> CreateMeasurement(string userId, int activityId);
    Task<Measurement> ReadMeasurement(int measurementId);
    Task<Measurement> ReadMeasurement(int measurementId, string userId);
    Task<Measurement> ReadSuspendedMeasurement(int projectId, string userId);
    Task UpdateMeasurement();
    Task DeleteMeasurement(int measurementId);
  }
}
