using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RCP.Models;
using RCP.ViewModels;

namespace RCP.Mapper
{
  public class MeasurementQuestionnaireAnswerMapper : Profile
  {
    public MeasurementQuestionnaireAnswerMapper()
    {
      CreateMap<MeasurementQuestionnaireAnswer, MeasurementQuestionnaireAnswerQueryDto>();
      CreateMap<MeasurementQuestionnaireAnswerCommandDto, MeasurementQuestionnaireAnswer>();
    }
  }
}
