using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.KeyVariables.CQRS.Command.Update;

public record KeyVariableUpdateCommand(Guid Id, string Name, int Priority, bool IsEnabled, string? Alias = null, string? Description = null) : IUpdateCommand<Guid, DTOs.KeyVariableDetailDto>;