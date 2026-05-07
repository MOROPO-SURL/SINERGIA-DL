using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjectKinds.CQRS.Command.Unarchive;

public record StrategicProjectKindUnarchiveCommand(Guid Id) : IUnarchiveCommand<Guid>;