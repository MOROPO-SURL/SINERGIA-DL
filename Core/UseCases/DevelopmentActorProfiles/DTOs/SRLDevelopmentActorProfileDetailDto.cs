using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Organizations.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.DevelopmentActorProfiles.DTOs;

public record SRLDevelopmentActorProfileDetailDto(Guid Id, OrganizationBasicDto Owner) : IDetailDto;
