using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Users.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PersonAggregate.Enumerations;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Persons.DTOs;

public record PersonDetailDto(
    Guid Id, 
    string Name, 
    bool IsEnabled, 
    bool IsArchived, 
    int Priority, 
    Sex Sex, 
    CivilStatus CivilStatus,
    EmailAddressDetailDto[] EmailAddresses,
    PhoneNumberDetailDto[] PhoneNumbers,
    PostalAddressDetailDto[] PostalAddresses,
    WebSiteAddressDetailDto[] WebSiteAddresses,
    string? LastName = null, 
    string? Alias = null, 
    string? About = null, 
    ImageBasicDto? Image = null,
    UserBasicDto? User = null) : IDetailDto;
