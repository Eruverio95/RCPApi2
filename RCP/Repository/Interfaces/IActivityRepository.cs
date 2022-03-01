using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RCP.Models;

namespace RCP.Repository.Interfaces
{
  public interface IActivityRepository
  {
    Task<Activity> CreateActivity(Activity model);
    Task<IList<Activity>> ReadActivities(int projectId);
    Task<Activity> ReadActivity(int projectId, int activityId);
    Task UpdateActivity();
    Task DeleteActivity(int projectId, int activityId);
    Task<IList<Activity>> SearchActivities(int projectId, string query);
  }
}
