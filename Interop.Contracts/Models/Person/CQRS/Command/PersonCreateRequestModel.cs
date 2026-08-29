using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Common.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Image.CQRS.Command;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.User.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Person.CQRS.Command;

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
    ImageCreateRequestModel? NewImage = null,
    UserBasicDtoModel? User = null);