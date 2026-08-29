using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Common.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Image.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.OrganizationKind.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Person.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Organization.DTOs;

public record OrganizationDetailDtoModel(
    Guid Id,
    string Name,
    bool IsEnabled,
    bool IsArchived,
    int Priority,
    OrganizationKindBasicDtoModel Kind,
    EmailAddressDetailDtoModel[] EmailAddresses,
    PhoneNumberDetailDtoModel[] PhoneNumbers,
    PostalAddressDetailDtoModel[] PostalAddresses,
    WebSiteAddressDetailDtoModel[] WebSiteAddresses,
    PersonBasicDtoModel[] RepresentativePersons,
    PersonBasicDtoModel[] NonRepresentativePersons,
    string? Alias = null,
    string? About = null,
    ImageBasicDtoModel? Image = null);