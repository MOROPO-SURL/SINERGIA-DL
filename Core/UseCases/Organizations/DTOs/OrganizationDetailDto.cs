using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.OrganizationKinds.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Persons.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Organizations.DTOs;

public record OrganizationDetailDto(
    Guid Id, 
    string Name, 
    bool IsEnabled, 
    bool IsArchived, 
    int Priority,
    OrganizationKindDetailDto Kind,
    EmailAddressDetailDto[] EmailAddresses,
    PhoneNumberDetailDto[] PhoneNumbers,
    PostalAddressDetailDto[] PostalAddresses,
    WebSiteAddressDetailDto[] WebSiteAddresses,
    PersonBasicDto[] RepresentativePersons,
    PersonBasicDto[] NonRepresentativePersons,
    string? Alias = null, 
    string? About = null, 
    ImageBasicDto? Image = null) : IDetailDto;
