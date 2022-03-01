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
  public class RoleRepository : Repository<Role>, IRoleRepository
  {
    public RoleRepository(RCPDbContext context) : base(context)
    {
    }

    public async Task<Role> CreateRole(Role model)
    {
      var result = await _set.AddAsync(model);

      if (!await SaveChangesAsync())
      {
        throw new CreateException($"Could not create {nameof(Role)}");
      }

      return result.Entity;
    }

    public async Task<Role> ReadRole(int roleId)
    {
      var result = await AsQueryable().SingleOrDefaultAsync(x => x.Id == roleId);

      if (result == null)
      {
        throw new NotFoundException($"Could not found {nameof(Role)}");
      }

      return result;
    }

    public async Task<IList<Role>> ReadRoles()
    {
      var result = await AsQueryable().ToListAsync();

      if (result == null)
      {
        throw new NotFoundException($"Could not found {nameof(Role)}");
      }

      return result;
    }

    public async Task UpdateRole()
    {
      if (!await SaveChangesAsync())
      {
        throw new UpdateException($"Could not update {nameof(Role)}");
      }
    }

    public async Task DeleteRole(int roleId)
    {
      var toDelete = await AsQueryable().SingleAsync(x => x.Id == roleId);
      if (toDelete == null)
      {
        throw new NotFoundException($"Could not found {nameof(Role)}");
      }
      var result = _set.Remove(toDelete);

      if (!await SaveChangesAsync())
      {
        throw new DeleteException($"Could not delete {nameof(Role)}");
      }
    }
  }
}
