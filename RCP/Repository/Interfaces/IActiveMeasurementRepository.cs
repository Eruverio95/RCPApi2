using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RCP.Models;

namespace RCP.Repository.Interfaces
{
  public interface IActiveMeasurementRepository
  {
    Task<ActiveMeasurement> CreateActiveMeasurement(string userId, int measurementId, DateTime start);
    Task<ActiveMeasurement> ReadActiveMeasurement(string userId);
    Task UpdateActiveMeasurement();
    Task DeleteActiveMeasurement(string userId);
  }
}
