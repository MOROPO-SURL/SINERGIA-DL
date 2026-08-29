namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Objectives.CQRS.Command.Create.Addon;

public record ObjectiveChallengeAddonCreateCommand(int Index, string Title, string? Description = null);