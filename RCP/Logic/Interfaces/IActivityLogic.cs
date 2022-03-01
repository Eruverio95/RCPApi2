using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RCP.ViewModels;

namespace RCP.Logic.Interfaces
{
  public interface IActivityLogic
  {
    Task<ActivityQueryDto> CreateActivity(int projectId, string userId, ActivityCommandDto viewModel);
    Task<IList<ActivityQueryDto>> ReadActivities(int projectId, string userId);
    Task<ActivityQueryDto> ReadActivity(int projectId, int activityId, string userId);
    Task<ActivityQueryDto> UpdateActivity(int projectId, int activityId, string userId, ActivityCommandDto viewModel);
    Task DeleteActivity(int projectId, int activityId);
    Task<IList<ActivityQueryDto>> SearchActivities(int projectId, string query);
  }
}
