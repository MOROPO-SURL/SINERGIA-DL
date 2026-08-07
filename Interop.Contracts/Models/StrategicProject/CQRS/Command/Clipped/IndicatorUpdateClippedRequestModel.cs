using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProject.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.UnitMeasurement.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProject.CQRS.Command.Clipped;

public record IndicatorUpdateClippedRequestModel(
Guid Id,
string Name,
UnitMeasurementBasicDtoModel UnitMeasurement,
int Priority,
IEnumerable<IndicatorMilestoneCreateClippedRequestModel> InMilestones,
IEnumerable<IndicatorMilestoneUpdateClippedRequestModel> PatchMilestones,
IEnumerable<IndicatorMilestoneDetailDtoModel> OutMilestones,
string? Alias = null);
