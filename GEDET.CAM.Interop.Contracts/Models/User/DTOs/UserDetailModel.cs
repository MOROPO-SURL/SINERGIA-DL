using MOROPO.GEDET.CAM.Interop.Contracts.Models.Common.DTOs;

namespace MOROPO.GEDET.CAM.Interop.Contracts.Models.User.DTOs;

public record UserDetailModel(
    string Id,
    string Name,
    bool Enabled,
    bool PasswordChangeRequired,
    bool HasFullAccess,
    int FailAuthenticationCount,
    string? LastName,
    DateTime? LastSessionDate,
    ImageModel? Image,
    Role.DTOs.RoleBasiclModel[] Roles);
