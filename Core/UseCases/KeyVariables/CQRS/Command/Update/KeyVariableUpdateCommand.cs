using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.KeyVariables.CQRS.Command.Update;

public record KeyVariableUpdateCommand(Guid Id, string Name, int Priority, bool IsEnabled, string? Alias = null, string? Description = null) : IUpdateCommand<Guid, DTOs.KeyVariableDetailDto>;