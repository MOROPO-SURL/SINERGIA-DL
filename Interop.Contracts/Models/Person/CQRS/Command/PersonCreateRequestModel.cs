using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Common.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Image.CQRS.Command;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.User.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Person.CQRS.Command;

public record PersonCreateRequestModel(
    string Name,
    int Priority,
    EmailAddressDetailDtoModel[] EmailAddresses,
    PhoneNumberDetailDtoModel[] PhoneNumbers,
    PostalAddressDetailDtoModel[] PostalAddresses,
    WebSiteAddressDetailDtoModel[] WebSiteAddresses,
    string? LastName = null,
    string? Alias = null,
    string? About = null,
    ImageCreateRequestModel? Image = null,
    UserBasicDtoModel? User = null);