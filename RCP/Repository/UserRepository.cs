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
  public class UserRepository : Repository<User>, IUserRepository
  {
    public UserRepository(RCPDbContext context) : base(context)
    {
    }

    public async Task<User> CreateUser(User model)
    {
      var result = await _set.AddAsync(model);

      if (!await SaveChangesAsync())
      {
        throw new CreateException($"Could not create {nameof(User)}");
      }

      return result.Entity;
    }

    public async Task<User> ReadUser(string userName)
    {
      var result = await AsQueryable().FirstOrDefaultAsync(x => x.Id == userName);

      if (result == null)
      {
        throw new NotFoundException($"Could not found {nameof(User)}");
      }

      return result;
    }

    public async Task<IList<User>> ReadUsers()
    {
      var result = await AsQueryable().ToListAsync();

      return result;
    }

    public async Task UpdateUser()
    {
      if (!await SaveChangesAsync())
      {
        throw new UpdateException($"Could not update {nameof(User)}");
      }
    }

    public async Task DeleteUser(string userId)
    {
      var toDelete = await AsQueryable().SingleAsync(x => x.Id == userId);

      if (toDelete == null)
      {
        throw new NotFoundException($"Could not found {nameof(User)}");
      }

      _set.Remove(toDelete);

      if (!await SaveChangesAsync())
      {
        throw new DeleteException($"Could not delete {nameof(User)}");
      }
    }

    public async Task<IList<User>> SearchUsers(int projectId, string query)
    {
      var allUsersInProject = await set.Set<UserProjectRole>().Include(x => x.User).Where(x => x.ProjectId == projectId).ToListAsync();
      var queryDb = allUsersInProject.Where(x => x.User.FirstName.Contains(query, StringComparison.CurrentCultureIgnoreCase) || x.User.LastName.Contains(query, StringComparison.CurrentCultureIgnoreCase));
      IList<User> result = new List<User>();
      foreach (var user in queryDb)
      {
        result.Add(user.User);
      }

      return result;
    }

    public async Task<IList<User>> SearchUsers(string query)
    {
      var result = await AsQueryable()
        .Where(x => x.Id.Contains(query) || x.FirstName.Contains(query, StringComparison.CurrentCultureIgnoreCase) || x.LastName.Contains(query, StringComparison.CurrentCultureIgnoreCase)).ToListAsync();

      return result;
    }
  }
}
