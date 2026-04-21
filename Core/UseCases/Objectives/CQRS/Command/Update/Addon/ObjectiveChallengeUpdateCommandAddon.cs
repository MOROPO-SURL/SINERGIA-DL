namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.CQRS.Command.Update.Addon;

public record ObjectiveChallengeUpdateCommandAddon(Guid Id, int Index, string Title, string? Description = null);
