using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Organization.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.SocialResponsabilityAction.DTOs;

public record SRLSocialResponsabilityActionBasicDtoModel(Guid Id, string Title, DateTime At, OrganizationBasicDtoModel Organization);