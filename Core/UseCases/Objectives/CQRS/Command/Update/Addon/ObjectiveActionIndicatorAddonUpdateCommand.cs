using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Objectives.CQRS.Command.Create.Addon;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Objectives.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.UnitMeasurements.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Objectives.CQRS.Command.Update.Addon;

public record ObjectiveActionIndicatorAddonUpdateCommand(
    Guid Id,
    string Name,
    UnitMeasurementBasicDto UnitMeasurement,
    int Priority,
    IEnumerable<ObjectiveActionIndicatorMilestoneCreateCommand> InMilestones,
    IEnumerable<ObjectiveActionIndicatorMilestoneAddonUpdateCommand> PatchMilestones,
    IEnumerable<ObjectiveActionIndicatorMilestoneDetailDto> OutMilestones,
    string? Alias = null,
    string? Description = null);
