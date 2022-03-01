using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RCP.Logic.Interfaces
{
  public interface IAuthorizationService
  {
    Task<bool> HaveRights(string userId, int projectId, int roleId);
    Task<bool> HaveRights(string userId, int roleId);
  }
}
