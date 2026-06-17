namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.CQRS.Command.Create.Addon;

public record ObjectiveActionAddonCreateCommand(int Index, string Title, string? Description = null);