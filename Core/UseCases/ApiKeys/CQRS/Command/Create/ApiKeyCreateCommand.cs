using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.ApiKeys.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.ApiKeys.CQRS.Command.Create;

public record ApiKeyCreateCommand(string Name, bool IsEnabled, DateTime ExpireAt, string[] Permissions, string? Host) : ICreateCommand<ApiKeyDetailDto>;