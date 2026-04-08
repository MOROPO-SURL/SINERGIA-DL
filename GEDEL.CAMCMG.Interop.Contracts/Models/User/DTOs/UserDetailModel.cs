using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Image.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Role.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.User.DTOs;

public record UserDetailModel(
    string Id,
    string Name,
    bool Enabled,
    bool PasswordChangeRequired,
    bool HasFullAccess,
    int FailAuthenticationCount,
    string? LastName,
    DateTime? LastSessionDate,
    ImageBasicModel? Image,
    RoleBasiclModel[] Roles);
