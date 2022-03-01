using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RCP.ViewModels;

namespace RCP.Logic.Interfaces
{
  public interface IRoleLogic
  {
    Task<RoleQueryDto> CreateRole(RoleCommandDto viewModel);
    Task<RoleQueryDto> ReadRole(int roleId);
    Task<IList<RoleQueryDto>> ReadRoles();
    Task<RoleQueryDto> UpdateRole(int roleId, RoleCommandDto viewModel);
    Task DeleteRole(int roleId);
  }
}
