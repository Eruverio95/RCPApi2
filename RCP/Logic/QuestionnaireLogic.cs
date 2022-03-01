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
  public class QuestionnaireLogic : IQuestionnaireLogic
  {
    private readonly IMapper _mapper;
    private readonly IMeasurementQuestionnaireAnswerRepository _measurementQuestionnaireAnswerRepository;
    private readonly IQuestionnaireRepository _questionnaireRepository;

    public QuestionnaireLogic(IMapper mapper, IMeasurementQuestionnaireAnswerRepository measurementQuestionnaireAnswerRepository, IQuestionnaireRepository questionnaireRepository)
    {
      _mapper = mapper;
      _measurementQuestionnaireAnswerRepository = measurementQuestionnaireAnswerRepository;
      _questionnaireRepository = questionnaireRepository;
    }

    public async Task<QuestionnaireQueryDto> ReadCurrentQuestionnaire(int projectId, int questionnaireId, string userId)
    {
      var query = await _questionnaireRepository.ReadQuestionnaire(projectId, questionnaireId);
      var result = _mapper.Map<QuestionnaireQueryDto>(query);

      return result;
    }

    public async Task<MeasurementQuestionnaireAnswerQueryDto> SaveCurrentQuestionnaireAnswer(int projectId, string userId, MeasurementQuestionnaireAnswerCommandDto viewModel)
    {
      var model = _mapper.Map<MeasurementQuestionnaireAnswer>(viewModel);
      var query = await _measurementQuestionnaireAnswerRepository.CreateMeasurementQuestionnaireAnswer(model.MeasurementId,
          model.Value);
      var result = _mapper.Map<MeasurementQuestionnaireAnswerQueryDto>(query);

      return result;
    }
  }
}