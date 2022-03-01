using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RCP.ViewModels;

namespace RCP.Logic.Interfaces
{
  public interface IProjectLogic
  {
    Task<ProjectQueryDto> CreateProject(string userId, ProjectCommandDto viewModel);
    Task<IList<ProjectQueryDto>> ReadActiveProjects();
    Task<ProjectQueryDto> ReadUserActiveProject(string userId);
    Task<ProjectQueryDto> ReadProject(int projectId);
    Task<IList<ProjectQueryDto>> ReadProjects();
    Task<IList<ProjectQueryDto>> ReadUserProjects(string userId);
    Task<ProjectQueryDto> UpdateProject(int projectId, string userId, ProjectCommandDto viewModel);
    Task DeleteProject(int projectId);
  }
}
