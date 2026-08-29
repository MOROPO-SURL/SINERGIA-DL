using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.ApiKeys.CQRS.Command.Update;

public record ApiKeyUpdateCommand(Guid Id, string Name, bool IsEnabled, DateTime ExpireAt, string[]? Permissions = null, string? Host = null) : IUpdateCommand<Guid, DTOs.ApiKeyDetailDto>;