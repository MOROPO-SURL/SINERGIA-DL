namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.CQRS.Command.Create.Addon;

public record ProgramActionAddonCreateCommand(Guid Id, string Title, int Priority, string? Description = null);