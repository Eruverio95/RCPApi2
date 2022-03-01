using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RCP.Models;

namespace RCP.Repository.Interfaces
{
  public interface IRoleRepository
  {
    Task<Role> CreateRole(Role model);
    Task<Role> ReadRole(int roleId);
    Task<IList<Role>> ReadRoles();
    Task UpdateRole();
    Task DeleteRole(int roleId);
  }
}
