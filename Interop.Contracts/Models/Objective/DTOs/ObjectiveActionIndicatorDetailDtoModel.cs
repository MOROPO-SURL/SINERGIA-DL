using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.UnitMeasurement.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Objective.DTOs;

public record ObjectiveActionIndicatorDetailDtoModel(
    Guid Id,
    string Name,
    UnitMeasurementBasicDtoModel UnitMeasurement,
    int Priority,
    ObjectiveActionIndicatorMilestoneDetailDtoModel[] Milestones,
    string? Alias = null);
