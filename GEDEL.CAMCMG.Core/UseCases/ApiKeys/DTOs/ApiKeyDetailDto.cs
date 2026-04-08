using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Permissions.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.ApiKeys.DTOs;

public record ApiKeyDetailDto(Guid Id, string Name, bool IsEnabled, DateTime ExpireAt, DateTime CreatedAt, PermissionDetailDto[] Permissions, DateTime? Updated = null, string? Host = null) : IDetailDto;