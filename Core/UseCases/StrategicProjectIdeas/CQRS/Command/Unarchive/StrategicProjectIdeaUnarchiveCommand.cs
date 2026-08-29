using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectIdeas.CQRS.Command.Unarchive;

public record StrategicProjectIdeaUnarchiveCommand(Guid Id) : IUnarchiveCommand<Guid>;