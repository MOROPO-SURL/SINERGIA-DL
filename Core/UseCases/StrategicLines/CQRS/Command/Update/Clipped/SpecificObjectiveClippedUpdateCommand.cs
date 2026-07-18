namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.CQRS.Command.Update.Clipped;

public record SpecificObjectiveClippedUpdateCommand(Guid Id, int Index, string Content);