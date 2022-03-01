using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RCP.Logic.Interfaces;
using RCP.Models;
using RCP.Repository.Interfaces;
using RCP.ViewModels;

namespace RCP.Logic
{
  public class ActivityLogic : IActivityLogic
  {
    private readonly IMapper _mapper;
    private readonly IActivityRepository _activityRepository;

    public ActivityLogic(IMapper mapper, IActivityRepository activityRepository)
    {
      _mapper = mapper;
      _activityRepository = activityRepository;
    }

    public async Task<ActivityQueryDto> CreateActivity(int projectId, string userId, ActivityCommandDto viewModel)
    {
      var model = _mapper.Map<Activity>(viewModel);
      model.ProjectId = projectId;
      var query = await _activityRepository.CreateActivity(model);
      var result = _mapper.Map<ActivityQueryDto>(query);

      return result;
    }

    public async Task<IList<ActivityQueryDto>> ReadActivities(int projectId, string userId)
    {
      var query = await _activityRepository.ReadActivities(projectId);
      var result = _mapper.Map<IList<ActivityQueryDto>>(query);

      return result;
    }

    public async Task<ActivityQueryDto> ReadActivity(int projectId, int activityId, string userId)
    {
      var query = await _activityRepository.ReadActivity(projectId, activityId);
      var result = _mapper.Map<ActivityQueryDto>(query);

      return result;
    }

    public async Task<ActivityQueryDto> UpdateActivity(int projectId, int activityId, string userId, ActivityCommandDto viewModel)
    {
      var activityExists = await _activityRepository.ReadActivity(projectId, activityId);
      _mapper.Map(viewModel, activityExists);
      await _activityRepository.UpdateActivity();
      var result = _mapper.Map<ActivityQueryDto>(activityExists);

      return result;
    }

    public async Task DeleteActivity(int projectId, int activityId)
    {
      await _activityRepository.DeleteActivity(projectId, activityId);
    }

    public async Task<IList<ActivityQueryDto>> SearchActivities(int projectId, string query)
    {
      var queryDb = await _activityRepository.SearchActivities(projectId, query);
      var result = _mapper.Map<IList<ActivityQueryDto>>(queryDb);

      return result;
    }
  }
}
