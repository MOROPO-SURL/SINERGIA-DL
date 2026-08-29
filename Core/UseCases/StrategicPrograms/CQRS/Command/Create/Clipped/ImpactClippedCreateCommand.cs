namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicPrograms.CQRS.Command.Create.Clipped;

public record ImpactClippedCreateCommand(Guid Id, string Name, int Priority, string? Description = null);