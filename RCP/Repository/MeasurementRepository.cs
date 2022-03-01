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
  public class MeasurementRepository : Repository<Measurement>, IMeasurementRepository
  {
    public MeasurementRepository(RCPDbContext context) : base(context)
    {
    }

    public async Task<Measurement> CreateMeasurement(string userId, int activityId)
    {
      var measurement = new Measurement() {UserId = userId, ActivityId = activityId, DateTimeStart = DateTime.Now};
      var result = await _set.AddAsync(measurement);

      if (!await SaveChangesAsync())
      {
        throw new CreateException($"Could not create {nameof(Measurement)}");
      }

      return result.Entity;
    }

    public async Task<Measurement> ReadMeasurement(int measurementId)
    {
      var result = await AsQueryable().SingleOrDefaultAsync(x => x.Id == measurementId);

      if (result == null)
      {
        throw new NotFoundException($"Could not found {nameof(Measurement)}");
      }

      return result;
    }

    public async Task<Measurement> ReadMeasurement(int measurementId, string userId)
    {
      var result = await AsQueryable().SingleOrDefaultAsync(x => x.Id == measurementId && x.UserId == userId);

      if (result == null)
      {
        throw new NotFoundException($"Could not found {nameof(Measurement)}");
      }

      return result;
    }

    public async Task<Measurement> ReadSuspendedMeasurement(int projectId, string userId)
    {
      var result = await AsQueryable().SingleOrDefaultAsync(x => x.Status == Enumerators.Enumerators.MeasurementStatus.Suspended && x.UserId == userId);

      if (result == null)
      {
        throw new NotFoundException($"Could not found {nameof(Measurement)}");
      }

      return result;
    }

    public async Task UpdateMeasurement()
    {
      if (!await SaveChangesAsync())
      {
        throw new UpdateException($"Could not update {nameof(Measurement)}");
      }
    }

    public async Task DeleteMeasurement(int measurementId)
    {
      var toDelete = await AsQueryable().SingleAsync(x => x.Id == measurementId);

      if (toDelete == null)
      {
        throw new NotFoundException($"Could not found {nameof(Measurement)}");
      }

      var result = _set.Remove(toDelete);

      if (!await SaveChangesAsync())
      {
        throw new DeleteException($"Could not delete {nameof(Measurement)}");
      }
    }
  }
}
