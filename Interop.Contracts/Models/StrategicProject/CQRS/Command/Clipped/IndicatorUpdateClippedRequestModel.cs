using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProject.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.UnitMeasurement.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProject.CQRS.Command.Clipped;

public record IndicatorUpdateClippedRequestModel(
Guid Id,
string Name,
UnitMeasurementBasicDtoModel UnitMeasurement,
int Priority,
IEnumerable<IndicatorMilestoneCreateClippedRequestModel> InMilestones,
IEnumerable<IndicatorMilestoneUpdateClippedRequestModel> PatchMilestones,
IEnumerable<IndicatorMilestoneDetailDtoModel> OutMilestones,
string? Alias = null);
