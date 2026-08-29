using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Image.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.OrganizationKind.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Organization.DTOs;

public record OrganizationBasicDtoModel(Guid Id, string Name, OrganizationKindBasicDtoModel Kind, string? Alias = null, ImageBasicDtoModel? Image = null);

