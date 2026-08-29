using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Permissions.DTOs;

public record PermissionDetailDto(string Id, string? Family, string? Description) : IDetailDto;