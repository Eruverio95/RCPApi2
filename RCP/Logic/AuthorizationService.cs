using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RCP.Logic.Interfaces;
using RCP.Repository.Interfaces;

namespace RCP.Logic
{
  public class AuthorizationService : IAuthorizationService
  {
    private readonly IUserProjectRoleRepository _userProjectRoleRepository;

    public AuthorizationService(IUserProjectRoleRepository userProjectRoleRepository)
    {
      _userProjectRoleRepository = userProjectRoleRepository;
    }
    
    public async Task<bool> HaveRights(string userId, int projectId, int roleId)
    {
      var result = await _userProjectRoleRepository.Is(projectId, userId, roleId);

      return result;
    }

    public async Task<bool> HaveRights(string userId, int roleId)
    {
      var result = await _userProjectRoleRepository.Is(userId, roleId);

      return result;
    }
  }
}
