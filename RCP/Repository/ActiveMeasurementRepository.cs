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
  public class ActiveMeasurementRepository : Repository<ActiveMeasurement>, IActiveMeasurementRepository
  {
    public ActiveMeasurementRepository(RCPDbContext context) : base(context)
    {
    }

    public async Task<ActiveMeasurement> CreateActiveMeasurement(string userId, int measurementId, DateTime start)
    {
      var model = new ActiveMeasurement() {UserId = userId, MeasurementId = measurementId, DateTimeStart = start};
      var result = await _set.AddAsync(model);

      if (!await SaveChangesAsync())
      {
        throw new CreateException($"Could not create {nameof(ActiveMeasurement)}");
      }

      return result.Entity;
    }

    public async Task<ActiveMeasurement> ReadActiveMeasurement(string userId)
    {
      var result = await AsQueryable().SingleOrDefaultAsync(x => x.UserId == userId);

      if (result == null)
      {
        throw new NotFoundException($"Could not found {nameof(ActiveMeasurement)}");
      }

      return result;
    }

    public async Task UpdateActiveMeasurement()
    {
      if (!await SaveChangesAsync())
      {
        throw new UpdateException($"Could not update {nameof(ActiveMeasurement)}");
      }
    }

    public async Task DeleteActiveMeasurement(string userId)
    {
      var toDelete = await AsQueryable().FirstAsync(x => x.UserId == userId);
      if (toDelete == null)
      {
        throw new NotFoundException($"Could not found {nameof(ActiveMeasurement)}");
      }
      var result = _set.Remove(toDelete);

      if (!await SaveChangesAsync())
      {
        throw new DeleteException($"Could not delete {nameof(ActiveMeasurement)}");
      }
    }
  }
}
