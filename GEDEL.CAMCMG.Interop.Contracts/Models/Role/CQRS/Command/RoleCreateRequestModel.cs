namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Role.CQRS.Command;

public record RoleCreateRequestModel(string Name, string[] Permissions, string? Description);
