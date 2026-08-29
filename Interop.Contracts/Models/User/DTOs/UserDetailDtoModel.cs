using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Image.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Role.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.User.DTOs;

public record UserDetailDtoModel(
    string Id,
    string Name,
    bool Enabled,
    bool PasswordChangeRequired,
    bool HasFullAccess,
    int FailAuthenticationCount,
    string? LastName,
    DateTime? LastSessionDate,
    ImageBasicDtoModel? Image,
    RoleBasicDtoModel[] Roles);
