namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjects.CQRS.Command.Update.Clipped;

public record SpecificObjectiveProjectClippedUpdateCommand(Guid Id, int Index, string Content);
