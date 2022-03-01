using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Newtonsoft.Json;
using RCP.Logic.Interfaces;
using RCP.Models;
using RCP.Repository.Exceptions;
using RCP.Repository.Interfaces;
using RCP.ViewModels;

namespace RCP.Logic
{
  public class UserLogic : IUserLogic
  {
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    private readonly IUserProjectRoleRepository _userProjectRoleRepository;

    public UserLogic(IMapper mapper, IUserRepository userRepository, IUserProjectRoleRepository userProjectRoleRepository)
    {
      _mapper = mapper;
      _userRepository = userRepository;
      _userProjectRoleRepository = userProjectRoleRepository;
    }

    public async Task<UserQueryDto> CreateUser(UserCommandDto viewModel)
    {
      var model = _mapper.Map<User>(viewModel);
      var query = await _userRepository.CreateUser(model);
      var result = _mapper.Map<UserQueryDto>(query);

      return result;
    }

    public async Task<UserProjectRoleQueryDto> CreateUserProjectRole(int projectId, string userId, int roleId)
    {
      var query = await _userProjectRoleRepository.CreateUserProjectRole(projectId, userId, roleId);
      var result = _mapper.Map<UserProjectRoleQueryDto>(query);

      return result;
    }

    public async Task<UserQueryDto> ReadUser(string userId)
    {
      var userExists = await _userRepository.ReadUser(userId);
      var result = _mapper.Map<UserQueryDto>(userExists);

      return result;
    }

    public async Task<IList<UserQueryDto>> ReadUsers()
    {
      var query = await _userRepository.ReadUsers();
      var result = _mapper.Map<IList<UserQueryDto>>(query);

      return result;
    }

    public async Task<IList<UserQueryDto>> ReadUsers(int projectId, int? roleId)
    {
      var query = await _userProjectRoleRepository.ReadUsersView(projectId);
      IList<User> users = new List<User>();
      if (roleId != null)
      {
        if (roleId.Equals(Enumerators.Enumerators.UserRoles.Administrator))
          query = query.Where(x => x.RoleId == 1).ToList();
        else if (roleId.Equals(Enumerators.Enumerators.UserRoles.User))
          query = query.Where(x => x.RoleId == 2).ToList();
      }
      foreach (var user in query)
      {
        users.Add(user.User);
      }
      var result = _mapper.Map<IList<UserQueryDto>>(users);

      return result;
    }

    public async Task<IList<UserQueryDto>> ReadUsersByRole(int roleId)
    {
      var query = await _userProjectRoleRepository.ReadUsersByRole(roleId);
      var result = _mapper.Map<IList<UserQueryDto>>(query);

      return result;
    }

    public async Task<IList<UserProjectRoleQueryDto>> ReadUserProjectRoles(int projectId, string userId)
    {
      var query = await _userProjectRoleRepository.ReadRoles(projectId, userId);
      var result = _mapper.Map<IList<UserProjectRoleQueryDto>>(query);

      return result;
    }

    public async Task<UserQueryDto> UpdateUser(string userId, UserCommandDto viewModel)
    {
      var userExists = await _userRepository.ReadUser(userId);
      _mapper.Map(viewModel, userExists);
      await _userRepository.UpdateUser();
      var result = _mapper.Map<UserQueryDto>(userExists);

      return result;
    }

    public async Task DeleteUser(string userId)
    {
      var userExists = await _userRepository.ReadUser(userId);
      await _userRepository.DeleteUser(userExists.Id);
    }

    public async Task DeleteUserProjectRole(int projectId, string userId, int roleId)
    {
      await _userProjectRoleRepository.DeleteRole(projectId, userId, roleId);
    }

    public async Task<UserProjectRoleQueryDto> AddUserToProject(int projectId, string userId)
    {
      var query = await _userProjectRoleRepository.CreateUserProjectRole(projectId, userId,
        (int)Enumerators.Enumerators.UserRoles.User);
      var result = _mapper.Map<UserProjectRoleQueryDto>(query);

      return result;
    }

    public async Task<IList<UserQueryDto>> SearchUsers(string query)
    {
      var queryDb = await _userRepository.SearchUsers(query);
      var result = _mapper.Map<IList<UserQueryDto>>(queryDb);

      return result;
    }

    public async Task<IList<UserQueryDto>> SearchUsersInProject(int projectId, string query)
    {
      var queryDb = await _userRepository.SearchUsers(projectId, query);
      var result = _mapper.Map<IList<UserQueryDto>>(queryDb);

      return result;
    }
    
    public async Task<string> Start(string userId)
    {
      return "Start RCP for user: " + userId.ToUpper();
    }

    public async Task<bool> UserExistsInProject(int projectId, string userId)
    {
      var result = await _userProjectRoleRepository.Is(projectId, userId, (int) Enumerators.Enumerators.UserRoles.User);

      return result;
    }
  }
}