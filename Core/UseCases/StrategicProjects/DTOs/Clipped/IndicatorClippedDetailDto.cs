using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.UnitMeasurements.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjects.DTOs.Clipped;

public record IndicatorClippedDetailDto(
Guid Id,
string Name,
UnitMeasurementBasicDto UnitMeasurement,
int Priority,
IndicatorMilestoneClippedDetailDto[] Milestones,
string? Alias = null) : IDetailDto;
