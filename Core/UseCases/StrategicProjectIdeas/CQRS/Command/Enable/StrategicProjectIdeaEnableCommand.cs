using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectIdeas.CQRS.Command.Enable;

public record StrategicProjectIdeaEnableCommand(Guid Id) : IEnableCommand<Guid>;