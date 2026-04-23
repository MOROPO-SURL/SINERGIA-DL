using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.KeyVariables.CQRS.Command.Remove;

public record KeyVariableRemoveCommand(Guid Id) : IRemoveCommand<Guid>;