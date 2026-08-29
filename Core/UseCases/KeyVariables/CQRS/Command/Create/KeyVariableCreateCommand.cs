using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.KeyVariables.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.KeyVariables.CQRS.Command.Create;

public record KeyVariableCreateCommand(string Name, int Priority, bool IsEnabled, string? Alias = null, string? Description = null) : ICreateCommand<KeyVariableDetailDto>;