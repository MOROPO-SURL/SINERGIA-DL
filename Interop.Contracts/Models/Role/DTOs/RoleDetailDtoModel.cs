namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Role.DTOs;

public record RoleDetailDtoModel(Guid Id, string Name, string? Description, string[] Permissions) : RoleBasicDtoModel(Id, Name);