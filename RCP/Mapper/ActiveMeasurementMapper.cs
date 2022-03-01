using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RCP.Models;
using RCP.ViewModels;

namespace RCP.Mapper
{
  public class ActiveMeasurementMapper : Profile
  {
    public ActiveMeasurementMapper()
    {
      CreateMap<ActiveMeasurement, ActiveMeasurementQueryDto>();
      CreateMap<ActiveMeasurementCommandDto, ActiveMeasurement>();
    }
  }
}
