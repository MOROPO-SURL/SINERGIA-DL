using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Organization.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.SocialResponsabilityAction.DTOs;

public record SRLSocialResponsabilityActionBasicDtoModel(Guid Id, string Title, DateTime At, OrganizationBasicDtoModel Organization);