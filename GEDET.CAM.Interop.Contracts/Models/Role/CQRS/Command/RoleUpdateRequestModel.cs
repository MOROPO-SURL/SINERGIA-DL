namespace MOROPO.GEDET.CAM.Interop.Contracts.Models.Role.CQRS.Command;

public record RoleUpdateRequestModel(Guid Id, string Name, string[] Permissions, string? Description);