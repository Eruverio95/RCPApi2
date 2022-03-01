using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RCP.Models;

namespace RCP.Repository.Interfaces
{
  public interface IUserProjectRoleRepository
  {
    Task<UserProjectRole> CreateUserProjectRole(int projectId, string userId, int roleId);
    Task<IList<UserProjectRole>> ReadRoles(int projectId, string userId);
    Task<IList<UserProjectRole>> ReadUsersByRole(int? roleId);
    Task<IList<UserProjectRole>> ReadUsersView(int projectId);
    Task DeleteRole(int projectId, string userId, int roleId);
    //Task DeleteAllRolesForUser(string userId);
    Task<bool> Is(int projectId, string userId, int roleId);
    Task<bool> Is(string userId, int roleId);
  }
}
