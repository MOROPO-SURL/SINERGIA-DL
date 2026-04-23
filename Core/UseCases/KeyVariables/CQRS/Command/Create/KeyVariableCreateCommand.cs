using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.KeyVariables.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.KeyVariables.CQRS.Command.Create;

public record KeyVariableCreateCommand(string Name, int Priority, bool IsEnabled, string? Alias = null, string? Description = null) : ICreateCommand<KeyVariableDetailDto>;