using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.CQRS.Command.Create.Addon;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.CQRS.Command.Update.Addon;

public record ObjectiveActionAddonUpdateCommand(
    Guid Id, 
    int Index, 
    string Title,
    IEnumerable<ObjectiveActionIndicatorCreateCommand> InIndicators,
    IEnumerable<ObjectiveActionIndicatorAddonUpdateCommand> PatchIndicators,
    IEnumerable<ObjectiveActionIndicatorDetailDto> OutIndicators,
    string? Description = null);