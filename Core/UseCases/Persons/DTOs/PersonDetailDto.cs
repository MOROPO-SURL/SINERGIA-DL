using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Users.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PersonAggregate.Enumerations;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Persons.DTOs;

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
