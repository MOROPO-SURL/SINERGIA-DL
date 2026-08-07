using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.UnitMeasurement.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProject.DTOs;

public record IndicatorDetailDtoModel(
Guid Id,
string Name,
UnitMeasurementBasicDtoModel UnitMeasurement,
int Priority,
IndicatorMilestoneDetailDtoModel[] Milestones,
string? Alias = null);
