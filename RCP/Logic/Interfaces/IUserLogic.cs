using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RCP.ViewModels;

namespace RCP.Logic.Interfaces
{
  public interface IUserLogic
  {
    Task<UserQueryDto> CreateUser(UserCommandDto viewModel);
    Task<UserProjectRoleQueryDto> CreateUserProjectRole(int projectId, string userId, int roleId);
    Task<UserQueryDto> ReadUser(string userId);
    Task<IList<UserQueryDto>> ReadUsers();
    Task<IList<UserQueryDto>> ReadUsers(int projectId, int? roleId);
    Task<IList<UserQueryDto>> ReadUsersByRole(int roleId);
    Task<IList<UserProjectRoleQueryDto>> ReadUserProjectRoles(int projectId, string userId);
    Task<UserQueryDto> UpdateUser(string userId, UserCommandDto viewModel);
    Task DeleteUser(string userId);
    Task DeleteUserProjectRole(int projectId, string userId, int roleId);
    Task<UserProjectRoleQueryDto> AddUserToProject(int projectId, string userId);
    Task<IList<UserQueryDto>> SearchUsers(string query);
    Task<IList<UserQueryDto>> SearchUsersInProject(int projectId, string query);
    Task<string> Start(string userId);
    Task<bool> UserExistsInProject(int projectId, string userId);
  }
}
