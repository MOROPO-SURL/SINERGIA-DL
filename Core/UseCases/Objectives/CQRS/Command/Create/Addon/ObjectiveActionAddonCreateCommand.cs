namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Objectives.CQRS.Command.Create.Addon;

public record ObjectiveActionAddonCreateCommand(
    Guid Id,
    int Index, 
    string Title,
    IEnumerable<ObjectiveActionIndicatorCreateCommand> Indicators,
    string? Description = null);