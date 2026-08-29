namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.User.CQRS.Command;

public record UserUpdateRequestModel(
    string Id,
    string Name,
    string Password,
    bool Enabled,
    bool HasFullAccess,
    bool PasswordChangeRequired,
    string? LasName,
    byte[]? ImageContent,
    Guid[]? Roles);
