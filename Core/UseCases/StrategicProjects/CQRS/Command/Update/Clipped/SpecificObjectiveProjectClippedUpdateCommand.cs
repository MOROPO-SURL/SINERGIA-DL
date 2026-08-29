namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjects.CQRS.Command.Update.Clipped;

public record SpecificObjectiveProjectClippedUpdateCommand(Guid Id, int Index, string Content);
