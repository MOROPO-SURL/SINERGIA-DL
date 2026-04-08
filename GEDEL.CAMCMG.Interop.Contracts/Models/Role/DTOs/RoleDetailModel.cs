namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Role.DTOs;

public record RoleDetailModel(Guid Id, string Name, string? Description, string[] permissions) : RoleBasiclModel(Id, Name);