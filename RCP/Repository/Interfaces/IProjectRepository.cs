using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RCP.Models;

namespace RCP.Repository.Interfaces
{
  public interface IProjectRepository
  {
    Task<Project> CreateProject(Project model);
    Task<IList<Project>> ReadProjects();
    Task<Project> ReadProject(int projectId);
    Task<IList<Project>> ReadActiveProjects();
    Task<Project> ReadUserActiveProject(string userId);
    Task<IList<Project>> ReadUserProjects(string userId);
    Task UpdateProject();
    Task DeleteProject(int projectId);
  }
}
