using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.KeyVariables.CQRS.Command.Remove;

public record KeyVariableRemoveCommand(Guid Id) : IRemoveCommand<Guid>;