using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.UnitMeasurements.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.DTOs.Clipped;

public record ActionIndicatorClippedDetailDto(
    Guid Id,
    string Name,
    UnitMeasurementBasicDto UnitMeasurement,
    ActionIndicatorMilestoneClippedDetailDto[] Milestones,
    ActionIndicatorChangeClippedDetailDto[] Changes,
    string? Alias = null) : IDetailDto;