using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RCP.Logic.Interfaces;
using RCP.Repository.Interfaces;
using RCP.ViewModels;

namespace RCP.Logic
{
  public class MeasurementLogic : IMeasurementLogic
  {
    private readonly IMapper _mapper;
    private readonly IActiveMeasurementRepository _activeMeasurementRepository;
    private readonly IMeasurementRepository _measurementRepository;

    public MeasurementLogic(IMapper mapper, IActiveMeasurementRepository activeMeasurementRepository, IMeasurementRepository measurementRepository)
    {
      _mapper = mapper;
      _activeMeasurementRepository = activeMeasurementRepository;
      _measurementRepository = measurementRepository;
    }

    public async Task CancelActiveMeasurement(int projectId, string userId)
    {
      var activeMeasurement = await _activeMeasurementRepository.ReadActiveMeasurement(userId);
      await _measurementRepository.DeleteMeasurement(activeMeasurement.MeasurementId);
    }

    public async Task ContinueActiveMeasurement(int projectId, string userId)
    {
      var suspended = await _measurementRepository.ReadSuspendedMeasurement(projectId, userId);
      suspended.Status = Enumerators.Enumerators.MeasurementStatus.Active;
      var activeMeasurement = await _activeMeasurementRepository.CreateActiveMeasurement(userId, suspended.Id, suspended.DateTimeStart);
    }

    public async Task<ActiveMeasurementQueryDto> ReadCurrentActiveMeasurement(string userId)
    {
      var query = _activeMeasurementRepository.ReadActiveMeasurement(userId);
      var result = _mapper.Map<ActiveMeasurementQueryDto>(query);

      return result;
    }

    public async Task<MeasurementQueryDto> ReadMeasurement(int measurementId, string userId)
    {
      var query = _measurementRepository.ReadMeasurement(measurementId);
      var result = _mapper.Map<MeasurementQueryDto>(query);

      return result;
    }
    
    public async Task<MeasurementQueryDto> ReadSuspendedMeasurement(int projectId, string userId)
    {
      var query = await _measurementRepository.ReadSuspendedMeasurement(projectId, userId);
      var result = _mapper.Map<MeasurementQueryDto>(query);

      return result;
    }

    public async Task<ActiveMeasurementQueryDto> StartActiveMeasurement(int projectId, int activityId, string userId)
    {
      var measurement = await _measurementRepository.CreateMeasurement(userId, activityId);
      var activeMeasurement = await _activeMeasurementRepository.CreateActiveMeasurement(userId, measurement.Id, DateTime.Now);
      var result = _mapper.Map<ActiveMeasurementQueryDto>(activeMeasurement);

      return result;
    }

    public async Task<MeasurementQueryDto> StopActiveMeasurement(string userId)
    {
      var activeMeasurement = await _activeMeasurementRepository.ReadActiveMeasurement(userId);
      await _activeMeasurementRepository.DeleteActiveMeasurement(userId);
      var measurement = await _measurementRepository.ReadMeasurement(activeMeasurement.MeasurementId);
      measurement.DateTimeEnd = DateTime.Now;
      measurement.Status = Enumerators.Enumerators.MeasurementStatus.Ended;
      measurement.Seconds += (measurement.DateTimeEnd - measurement.DateTimeStart).Seconds;
      await _measurementRepository.UpdateMeasurement();
      var result = _mapper.Map<MeasurementQueryDto>(measurement);

      return result;
    }

    public async Task<MeasurementQueryDto> SuspendActiveMeasurement(string userId, bool temp = false)
    {
      var activeMeasurement = await _activeMeasurementRepository.ReadActiveMeasurement(userId);
      await _activeMeasurementRepository.DeleteActiveMeasurement(userId);
      var suspendedMeasurement = await _measurementRepository.ReadMeasurement(activeMeasurement.MeasurementId);
      suspendedMeasurement.Status = Enumerators.Enumerators.MeasurementStatus.Suspended;
      suspendedMeasurement.Seconds = (DateTime.Now - suspendedMeasurement.DateTimeStart).Seconds;
      await _measurementRepository.UpdateMeasurement();
      var result = _mapper.Map<MeasurementQueryDto>(suspendedMeasurement);

      return result;
    }
  }
}