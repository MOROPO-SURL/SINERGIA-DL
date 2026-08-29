using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.UnitMeasurement.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Objective.CQRS.Command;

public record ObjectiveActionIndicatorCreateRequestModel(
Guid Id,
string Name,
UnitMeasurementBasicDtoModel UnitMeasurement,
int Priority,
IEnumerable<ObjectiveActionIndicatorMilestoneCreateRequestModel> Milestones,
string? Alias = null);
