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
  public class ProjectLogic : IProjectLogic
  {
    private readonly IMapper _mapper;
    private readonly IProjectRepository _projectRepository;

    public ProjectLogic(IMapper mapper, IProjectRepository projectRepository)
    {
      _mapper = mapper;
      _projectRepository = projectRepository;
    }

    public async Task<ProjectQueryDto> CreateProject(string userId, ProjectCommandDto viewModel)
    {
      var model = _mapper.Map<Project>(viewModel);
      var query = await _projectRepository.CreateProject(model);
      var result = _mapper.Map<ProjectQueryDto>(query);

      return result;
    }

    public async Task<IList<ProjectQueryDto>> ReadActiveProjects()
    {
      var query = await _projectRepository.ReadActiveProjects();
      var result = _mapper.Map<IList<ProjectQueryDto>>(query);

      return result;
    }

    public async Task<ProjectQueryDto> ReadUserActiveProject(string userId)
    {
      var query = await _projectRepository.ReadUserActiveProject(userId);
      var result = _mapper.Map<ProjectQueryDto>(query);

      return result;
    }

    public async Task<ProjectQueryDto> ReadProject(int projectId)
    {
      var query = await _projectRepository.ReadProject(projectId);
      var result = _mapper.Map<ProjectQueryDto>(query);

      return result;
    }

    public async Task<IList<ProjectQueryDto>> ReadProjects()
    {
      var query = await _projectRepository.ReadProjects();
      var result = _mapper.Map<IList<ProjectQueryDto>>(query);

      return result;
    }

    public async Task<IList<ProjectQueryDto>> ReadUserProjects(string userId)
    {
      var query = await _projectRepository.ReadUserProjects(userId);
      var result = _mapper.Map<IList<ProjectQueryDto>>(query);

      return result;
    }

    public async Task<ProjectQueryDto> UpdateProject(int projectId, string userId, ProjectCommandDto viewModel)
    {
      var projectExists = await _projectRepository.ReadProject(projectId);
      _mapper.Map(viewModel, projectExists);
      await _projectRepository.UpdateProject();
      var result = _mapper.Map<ProjectQueryDto>(projectExists);

      return result;
    }

    public async Task DeleteProject(int projectId)
    {
      await _projectRepository.DeleteProject(projectId);
    }
  }
}