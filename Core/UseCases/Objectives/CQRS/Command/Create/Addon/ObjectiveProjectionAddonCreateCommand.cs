namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.CQRS.Command.Create.Addon;

public record ObjectiveProjectionAddonCreateCommand(int Index, string Title, string? Description = null);