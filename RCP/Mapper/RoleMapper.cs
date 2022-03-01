using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RCP.Models;
using RCP.ViewModels;

namespace RCP.Mapper
{
  public class RoleMapper : Profile
  {
    public RoleMapper()
    {
      CreateMap<Role, RoleQueryDto>();
      CreateMap<RoleCommandDto, Role>();
    }
  }
}
