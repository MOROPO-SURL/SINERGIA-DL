using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.UnitMeasurements.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjects.DTOs.Clipped;

public record IndicatorClippedDetailDto(
Guid Id,
string Name,
UnitMeasurementBasicDto UnitMeasurement,
int Priority,
IndicatorMilestoneClippedDetailDto[] Milestones,
string? Alias = null) : IDetailDto;
