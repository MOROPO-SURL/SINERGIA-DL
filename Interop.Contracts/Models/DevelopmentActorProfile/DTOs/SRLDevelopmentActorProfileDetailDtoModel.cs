using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.EconomicActivity.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Organization.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.DevelopmentActorProfile.DTOs;

public record SRLDevelopmentActorProfileDetailDtoModel(
    Guid Id,
    OrganizationBasicDtoModel Owner,
    string FiscalIdentificationCode,
    EconomicActivityBasicDtoModel MainEconomicActivity,
    IEnumerable<EconomicActivityBasicDtoModel> SecoundaryEconomicActivities,
    string? About = null);