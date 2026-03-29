namespace MOROPO.GEDET.CAM.Interop.Contracts.Models.Role.DTOs;

public record RoleDetailModel(Guid Id, string Name, string? Description, string[] permissions) : RoleEssentialModel(Id, Name);