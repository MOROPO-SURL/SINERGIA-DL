namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicPrograms.CQRS.Command.Update.Clipped;

public record SpecificObjectiveClippedUpdateCommand(Guid Id, int Index, string Content);