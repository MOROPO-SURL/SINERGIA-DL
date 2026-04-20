using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Macroprograms.CQRS.Command.Remove;

public record MacroprogramRemoveCommand(Guid Id) : IRemoveCommand<Guid>;

