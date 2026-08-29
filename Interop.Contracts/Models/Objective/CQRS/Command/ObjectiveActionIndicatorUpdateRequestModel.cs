using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Objective.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.UnitMeasurement.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Objective.CQRS.Command;

public record ObjectiveActionIndicatorUpdateRequestModel(
    Guid Id,
    string Name,
    UnitMeasurementBasicDtoModel UnitMeasurement,
    int Priority,
    IEnumerable<ObjectiveActionIndicatorMilestoneCreateRequestModel> InMilestones,
    IEnumerable<ObjectiveActionIndicatorMilestoneUpdateRequestModel> PatchMilestones,
    IEnumerable<ObjectiveActionIndicatorMilestoneDetailDtoModel> OutMilestones,
    string? Alias = null);
