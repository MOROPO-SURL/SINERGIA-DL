using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Permissions.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.ApiKeys.DTOs;

public record ApiKeyDetailDto(Guid Id, string Name, bool IsEnabled, DateTime ExpireAt, string Token, DateTime CreatedAt, PermissionDetailDto[] Permissions, DateTime? Updated = null, string? Host = null) : IDetailDto;