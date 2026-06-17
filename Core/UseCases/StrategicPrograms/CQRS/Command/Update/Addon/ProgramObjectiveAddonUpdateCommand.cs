namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.CQRS.Command.Create.Addon;

public record ProgramObjectiveAddonUpdateCommand(int Id, string Name, bool IsEnabled, string? Description = null);