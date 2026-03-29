namespace MOROPO.GEDET.CAM.Interop.Contracts.Models.Role.CQRS.Command;

public record RoleCreateRequestModel(string Name, string[] Permissions, string? Description);
