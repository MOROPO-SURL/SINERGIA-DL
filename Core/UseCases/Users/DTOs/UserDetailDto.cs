using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Roles.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Users.DTOs;

public record UserDetailDto(string Id, string Name, bool IsEnabled, bool HasFullAccess, bool IsPasswordChangeRequired, DateTime CreatedAt, DateTime? UpdatedAt, RoleDetailDto[] Roles, string? LastName = null) : IDetailDto;