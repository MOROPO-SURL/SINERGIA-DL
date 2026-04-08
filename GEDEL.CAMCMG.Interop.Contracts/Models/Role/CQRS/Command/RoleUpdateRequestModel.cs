namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Role.CQRS.Command;

public record RoleUpdateRequestModel(Guid Id, string Name, string[] Permissions, string? Description);