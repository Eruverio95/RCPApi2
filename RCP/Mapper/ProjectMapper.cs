using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RCP.Models;
using RCP.ViewModels;

namespace RCP.Mapper
{
  public class ProjectMapper : Profile
  {
    public ProjectMapper()
    {
      CreateMap<Project, ProjectQueryDto>();
      CreateMap<ProjectCommandDto, Project>();
    }
  }
}
