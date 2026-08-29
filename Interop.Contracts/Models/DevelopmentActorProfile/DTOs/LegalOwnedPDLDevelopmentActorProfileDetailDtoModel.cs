using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.EconomicActivity.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Location.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Organization.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.PDLModality.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.DevelopmentActorProfile.DTOs;

public record LegalOwnedPDLDevelopmentActorProfileDetailDtoModel(
    Guid Id,
    OrganizationBasicDtoModel Owner,
    string FiscalIdentificationCode,
    DateOnly BornAt,
    PDLModalityBasicDtoModel Modality,
    EconomicActivityBasicDtoModel MainEconomicActivity,
    IEnumerable<EconomicActivityBasicDtoModel> SecoundaryEconomicActivities,
    LocationDetailDtoModel MainLocation,
    IEnumerable<LocationDetailDtoModel> CommercialLocations,
    OrganizationBasicDtoModel Holder,
    string? About = null);