namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.CQRS.Command.Create.Clipped;

public record ImpactClippedCreateCommand(Guid Id, string Name, int Priority, string? Description = null);