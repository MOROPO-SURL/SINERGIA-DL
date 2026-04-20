using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.ApiKeys.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.ApiKeys.CQRS.Command.Create;

public record ApiKeyCreateCommand(string Name, bool IsEnabled, DateTime ExpireAt, string[] Permissions, string? Host) : ICreateCommand<ApiKeyDetailDto>;