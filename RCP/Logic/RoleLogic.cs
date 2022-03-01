using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RCP.Logic.Interfaces;
using RCP.Models;
using RCP.Repository.Interfaces;
using RCP.ViewModels;

namespace RCP.Logic
{
  public class RoleLogic : IRoleLogic
  {
    private readonly IMapper _mapper;
    private readonly IRoleRepository _roleRepository;

    public RoleLogic(IMapper mapper, IRoleRepository roleRepository)
    {
      _mapper = mapper;
      _roleRepository = roleRepository;
    }

    public async Task<RoleQueryDto> CreateRole(RoleCommandDto viewModel)
    {
      var newRole = _mapper.Map<Role>(viewModel);
      var query = await _roleRepository.CreateRole(newRole);
      var result = _mapper.Map<RoleQueryDto>(query);

      return result;
    }

    public async Task<RoleQueryDto> ReadRole(int roleId)
    {
      var query = await _roleRepository.ReadRole(roleId);
      var result = _mapper.Map<RoleQueryDto>(query);

      return result;
    }

    public async Task<IList<RoleQueryDto>> ReadRoles()
    {
      var query = await _roleRepository.ReadRoles();
      var result = _mapper.Map<IList<RoleQueryDto>>(query);

      return result;
    }

    public async Task<RoleQueryDto> UpdateRole(int roleId, RoleCommandDto viewModel)
    {
      var roleExists = await _roleRepository.ReadRole(roleId);
      _mapper.Map(viewModel, roleExists);
      await _roleRepository.UpdateRole();
      var result = _mapper.Map<RoleQueryDto>(roleExists);

      return result;
    }

    public async Task DeleteRole(int roleId)
    {
      await _roleRepository.DeleteRole(roleId);
    }
  }
}
