namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.CQRS.Command.Create.Addon;

public record ProgramActionAddonUpdateCommand(Guid Id, string Title, int Priority, string? Description = null);