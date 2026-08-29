namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Role.DTOs;

public record RoleDetailDtoModel(Guid Id, string Name, string? Description, string[] Permissions) : RoleBasicDtoModel(Id, Name);