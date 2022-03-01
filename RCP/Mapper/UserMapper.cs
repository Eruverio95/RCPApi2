using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RCP.Models;
using RCP.ViewModels;

namespace RCP.Mapper
{
  public class UserMapper : Profile
  {
    public UserMapper()
    {
      CreateMap<User, UserQueryDto>();
      CreateMap<UserCommandDto, User>();
    }
  }
}
