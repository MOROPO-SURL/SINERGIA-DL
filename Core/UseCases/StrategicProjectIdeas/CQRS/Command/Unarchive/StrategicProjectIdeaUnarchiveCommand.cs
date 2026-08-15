using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjectIdeas.CQRS.Command.Unarchive;

public record StrategicProjectIdeaUnarchiveCommand(Guid Id) : IUnarchiveCommand<Guid>;