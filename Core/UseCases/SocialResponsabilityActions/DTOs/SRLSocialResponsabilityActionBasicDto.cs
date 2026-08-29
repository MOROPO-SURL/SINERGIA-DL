using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Organizations.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.SocialResponsabilityActions.DTOs;

public record SRLSocialResponsabilityActionBasicDto(Guid Id, string Title, DateTime At, OrganizationBasicDto Organization) : IDto;