using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Common.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Image.CQRS.Command;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Organization.CQRS.Command;

public record OrganizationCreateRequestModel(
    string Name,
    bool IsEnabled,
    int Priority,
    Guid KindId,
    EmailAddressDetailDtoModel[] EmailAddresses,
    PhoneNumberDetailDtoModel[] PhoneNumbers,
    PostalAddressDetailDtoModel[] PostalAddresses,
    WebSiteAddressDetailDtoModel[] WebSiteAddresses,
    OrganizationPersonRelationshipConfigurationRequestModel[] PersonRelationships,
    string? About = null,
    ImageCreateRequestModel? NewImage = null);
