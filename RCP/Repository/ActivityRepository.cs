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
  public class ActivityRepository : Repository<Activity>, IActivityRepository
  {
    public ActivityRepository(RCPDbContext context) : base(context)
    {
    }

    public async Task<Activity> CreateActivity(Activity model)
    {
      var result = await _set.AddAsync(model);

      if (!await SaveChangesAsync())
      {
        throw new CreateException($"Could not create {nameof(Activity)}");
      }

      return result.Entity;
    }

    public async Task<IList<Activity>> ReadActivities(int projectId)
    {
      var result = await AsQueryable().Where(x => x.ProjectId == projectId).ToListAsync();

      if (result == null)
      {
        throw new NotFoundException($"Could not found {nameof(Activity)}");
      }

      return result;
    }

    public async Task<Activity> ReadActivity(int projectId, int activityId)
    {
      var result = await AsQueryable().SingleOrDefaultAsync();

      if (result == null)
      {
        throw new NotFoundException($"Could not found {nameof(Activity)}");
      }

      return result;
    }

    public async Task UpdateActivity()
    {
      if (!await SaveChangesAsync())
      {
        throw new UpdateException($"Could not update {nameof(Activity)}");
      }
    }

    public async Task DeleteActivity(int projectId, int activityId)
    {
      var toDelete = await AsQueryable().SingleAsync(x => x.ProjectId == projectId && x.Id == activityId);
      if (toDelete == null)
      {
        throw new NotFoundException($"Could not found {nameof(Activity)}");
      }
      var result = _set.Remove(toDelete);

      if (!await SaveChangesAsync())
      {
        throw new DeleteException($"Could not delete {nameof(Activity)}");
      }
    }

    public async Task<IList<Activity>> SearchActivities(int projectId, string query)
    {
      var result = await AsQueryable().Where(x => x.ProjectId == projectId && x.Name.Contains(query, StringComparison.CurrentCultureIgnoreCase)).ToListAsync();

      return result;
    }
  }
}
