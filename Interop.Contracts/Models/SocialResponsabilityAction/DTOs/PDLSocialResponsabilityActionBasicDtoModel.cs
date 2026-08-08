using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Organization.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.SocialResponsabilityAction.DTOs;

public record PDLSocialResponsabilityActionBasicDtoModel(Guid Id, string Title, DateTime At, OrganizationBasicDtoModel Organization);