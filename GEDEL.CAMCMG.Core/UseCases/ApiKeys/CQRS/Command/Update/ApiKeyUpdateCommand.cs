using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.ApiKeys.CQRS.Command.Update;

public record ApiKeyUpdateCommand(Guid Id, string Name, string[]? Permissions = null) : IUpdateCommand<Guid, DTOs.ApiKeyDetailDto>;