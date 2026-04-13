using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Roles.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Users.DTOs;

public record UserDetailDto(string Id, string Name, bool IsEnabled, bool HasFullAccess, bool IsPasswordChangeRequired, DateTime CreatedAt, DateTime? UpdatedAt, RoleDetailDto[] Roles, string? LastName = null) : IDetailDto;