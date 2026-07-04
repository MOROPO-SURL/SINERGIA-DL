using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Common.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Image.CQRS.Command;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Person.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Organization.CQRS.Command;

public record OrganizationUpdateRequestModel(
    Guid Id,
    string Name,
    bool IsEnabled,
    int Priority,
    Guid OrganizationKindId,
    EmailAddressDetailDtoModel[] InEmailAddresses,
    EmailAddressDetailDtoModel[] OutEmailAddresses,
    PhoneNumberDetailDtoModel[] InPhoneNumbers,
    PhoneNumberDetailDtoModel[] OutPhoneNumbers,
    PostalAddressDetailDtoModel[] InPostalAddresses,
    PostalAddressDetailDtoModel[] OutPostalAddresses,
    WebSiteAddressDetailDtoModel[] InWebSiteAddresses,
    WebSiteAddressDetailDtoModel[] OutWebSiteAddresses,
    OrganizationPersonRelationshipConfigurationRequestModel[] InPersonRelationships,
    OrganizationPersonRelationshipConfigurationRequestModel[] PatchPersonRelationships,
    PersonBasicDtoModel[] OutPersonRelationships,
    Enumerations.DevelopmentActorProfileKind? DevelopmentActorProfileKind = null,
    string? About = null,
    ImageCreateRequestModel? Image = null);
