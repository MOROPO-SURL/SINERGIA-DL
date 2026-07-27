using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjectIdeas.CQRS.Command.Remove;

public record StrategicProjectIdeaRemoveCommand(Guid Id) : IRemoveCommand<Guid>;