using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.UnitMeasurements.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.CQRS.Command.Create.Addon;

public record ObjectiveActionIndicatorCreateCommand(
    Guid Id,
    string Name,
    UnitMeasurementBasicDto UnitMeasurement,
    int Priority,
    IEnumerable<ObjectiveActionIndicatorMilestoneCreateCommand> Milestones,
    string? Alias = null,
    string? Description = null);
