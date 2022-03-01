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
  public class ProjectRepository : Repository<Project>, IProjectRepository
  {
    public ProjectRepository(RCPDbContext context) : base(context)
    {
    }

    public async Task<Project> CreateProject(Project model)
    {
      var result = await _set.AddAsync(model);

      if (!await SaveChangesAsync())
      {
        throw new CreateException($"Could not create {nameof(Project)}");
      }

      return result.Entity;
    }

    public async Task<IList<Project>> ReadProjects()
    {
      var result = await AsQueryable().ToListAsync();

      if (result == null)
      {
        throw new NotFoundException($"Could not found {nameof(Project)}");
      }

      return result;
    }

    public async Task<Project> ReadProject(int projectId)
    {
      var result = await AsQueryable().SingleOrDefaultAsync(x => x.Id == projectId);

      if (result == null)
      {
        throw new NotFoundException($"Could not found {nameof(Project)}");
      }

      return result;
    }

    public async Task<IList<Project>> ReadActiveProjects()
    {
      var now = DateTime.Now;
      var result = await AsQueryable().Where(x => x.DateTimeStart < now && x.DateTimeEnd > now).ToListAsync();

      if (result == null)
      {
        throw new NotFoundException($"Could not found {nameof(Project)}");
      }

      return result;
    }

    public async Task<Project> ReadUserActiveProject(string userId)
    {
      var result = await set.Set<UserProjectRole>().Include(x => x.Project)
        .FirstOrDefaultAsync(x => x.UserId == userId && (x.Project.DateTimeStart < DateTime.Now && x.Project.DateTimeEnd > DateTime.Now));

      return result.Project;
    }

    public async Task<IList<Project>> ReadUserProjects(string userId)
    {
      var queryDb = await set.Set<UserProjectRole>().Include(x => x.Project).Where(x => x.UserId == userId).ToListAsync();
      IList<Project> result = new List<Project>();
      foreach (var project in queryDb)
      {
        result.Add(project.Project);
      }

      return result;
    }

    public async Task UpdateProject()
    {
      if (!await SaveChangesAsync())
      {
        throw new UpdateException($"Could not update {nameof(Project)}");
      }
    }

    public async Task DeleteProject(int projectId)
    {
      var toDelete = await AsQueryable().SingleAsync(x => x.Id == projectId);
      if (toDelete == null)
      {
        throw new NotFoundException($"Could not found {nameof(Project)}");
      }
      var result = _set.Remove(toDelete);

      if (!await SaveChangesAsync())
      {
        throw new DeleteException($"Could not delete {nameof(Project)}");
      }
    }
  }
}
