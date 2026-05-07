using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Common.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Image.CQRS.Command;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Person.CQRS.Command;

public record PersonUpdateRequestModel(
    Guid Id,
    string Name,
    int Priority,
    EmailAddressDetailDtoModel[] InEmailAddresses,
    EmailAddressDetailDtoModel[] OutEmailAddresses,
    PhoneNumberDetailDtoModel[] InPhoneNumbers,
    PhoneNumberDetailDtoModel[] OutPhoneNumbers,
    PostalAddressDetailDtoModel[] InPostalAddresses,
    PostalAddressDetailDtoModel[] OutPostalAddresses,
    WebSiteAddressDetailDtoModel[] InWebSiteAddresses,
    WebSiteAddressDetailDtoModel[] OutWebSiteAddresses,
    string? LastName = null,
    string? Alias = null,
    string? About = null,
    ImageCreateRequestModel? Image = null);