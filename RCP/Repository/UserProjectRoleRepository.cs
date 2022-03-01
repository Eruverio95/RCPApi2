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
  public class UserProjectRoleRepository : Repository<UserProjectRole>, IUserProjectRoleRepository
  {
    public UserProjectRoleRepository(RCPDbContext context) : base(context)
    {
    }

    public async Task<UserProjectRole> CreateUserProjectRole(int projectId, string userId, int roleId)
    {
      var model = new UserProjectRole() {UserId = userId, ProjectId = projectId, RoleId = roleId};
      var result = await _set.AddAsync(model);

      if (!await SaveChangesAsync())
      {
        throw new CreateException($"Could not create {nameof(UserProjectRole)}");
      }

      return result.Entity;
    }

    public async Task<IList<UserProjectRole>> ReadRoles(int projectId, string userId)
    {
      var result = await AsQueryable().Where(x => x.ProjectId == projectId && x.UserId == userId).ToListAsync();

      return result;
    }

    public async Task<IList<UserProjectRole>> ReadUsersByRole(int? roleId)
    {
      var result = await AsQueryable().Where(x => x.RoleId == roleId).ToListAsync();

      return result;
    }

    public async Task<IList<UserProjectRole>> ReadUsersView(int projectId)
    {
      var result = await AsQueryable().Include(x => x.User).Where(x => x.ProjectId == projectId).ToListAsync();

      return result;
    }

    public async Task DeleteRole(int projectId, string userId, int roleId)
    {
      var toDelete = await AsQueryable()
        .SingleAsync(x => x.ProjectId == projectId && x.UserId == userId && x.RoleId == roleId);
      if (toDelete == null)
      {
        throw new NotFoundException($"Could not found {nameof(UserProjectRole)}");
      }

      var result = _set.Remove(toDelete);

      if (!await SaveChangesAsync())
      {
        throw new DeleteException($"Could not delete {nameof(UserProjectRole)}");
      }
    }

    public async Task<bool> Is(int projectId, string userId, int roleId)
    {
      var result = await AsQueryable().AnyAsync(x => x.ProjectId == projectId && x.UserId == userId && x.RoleId == roleId);

      return result;
    }

    public async Task<bool> Is(string userId, int roleId)
    {
      var result = await AsQueryable().AnyAsync(x => x.UserId == userId && x.RoleId == roleId);

      return result;
    }
  }
}
