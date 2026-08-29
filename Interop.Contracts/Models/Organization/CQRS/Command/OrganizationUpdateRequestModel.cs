using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Common.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Image.CQRS.Command;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Person.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Organization.CQRS.Command;

public record OrganizationUpdateRequestModel(
    Guid Id,
    string Name,
    bool IsEnabled,
    int Priority,
    Guid KindId,
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
    string? About = null,
    ImageCreateRequestModel? NewImage = null);
