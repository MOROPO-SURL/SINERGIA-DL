using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjectKinds.CQRS.Command.Archive;

public record StrategicProjectKindArchiveCommand(Guid Id) : IArchiveCommand<Guid>;