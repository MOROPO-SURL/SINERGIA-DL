using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Common.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Image.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.User.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Person.DTOs;

public record PersonDetailDtoModel(
    Guid Id,
    string Name,
    bool IsEnabled,
    int Priority,
    EmailAddressDetailDtoModel[] EmailAddresses,
    PhoneNumberDetailDtoModel[] PhoneNumbers,
    PostalAddressDetailDtoModel[] PostalAddresses,
    WebSiteAddressDetailDtoModel[] WebSiteAddresses,
    string? LastName = null,
    string? Alias = null,
    string? About = null,
    ImageBasicDtoModel? Image = null,
    UserBasicDtoModel? User = null);