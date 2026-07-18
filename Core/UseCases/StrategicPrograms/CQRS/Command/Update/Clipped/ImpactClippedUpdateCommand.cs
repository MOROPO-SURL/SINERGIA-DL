namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.CQRS.Command.Update.Clipped;

public record ImpactClippedUpdateCommand(Guid Id, string Name, int Priority, string? Description = null);