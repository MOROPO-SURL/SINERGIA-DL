using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Common.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Image.CQRS.Command;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Organization.CQRS.Command;

public record OrganizationCreateRequestModel(
    string Name,
    bool IsEnabled,
    int Priority,
    Guid OrganizationKindId,
    EmailAddressDetailDtoModel[] EmailAddresses,
    PhoneNumberDetailDtoModel[] PhoneNumbers,
    PostalAddressDetailDtoModel[] PostalAddresses,
    WebSiteAddressDetailDtoModel[] WebSiteAddresses,
    OrganizationPersonRelationshipConfigurationRequestModel[] PersonRelationships,
    Enumerations.DevelopmentActorProfileKind? DevelopmentActorProfileKind = null,
    string? About = null,
    ImageCreateRequestModel? Image = null);
