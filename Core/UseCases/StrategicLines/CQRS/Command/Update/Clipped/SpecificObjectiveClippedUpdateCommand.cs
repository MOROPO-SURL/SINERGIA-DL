namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicLines.CQRS.Command.Update.Clipped;

public record SpecificObjectiveClippedUpdateCommand(Guid Id, int Index, string Content);