using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.KeyVariables.CQRS.Command.Unarchive;

public record KeyVariableUnarchiveCommand(Guid Id) : IUnarchiveCommand<Guid>;