using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Persons.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Users.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PersonAggregate.Enumerations;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Persons.CQRS.Command.Update;

public record PersonUpdateCommand(
    Guid Id,
    string Name,
    bool IsEnabled,
    bool IsArchived,
    int Priority,
    Sex Sex,
    CivilStatus CivilStatus,
    EmailAddressDetailDto[] InEmailAddresses,
    EmailAddressDetailDto[] OutEmailAddresses,
    PhoneNumberDetailDto[] InPhoneNumbers,
    PhoneNumberDetailDto[] OutPhoneNumbers,
    PostalAddressDetailDto[] InPostalAddresses,
    PostalAddressDetailDto[] OutPostalAddresses,
    WebSiteAddressDetailDto[] InWebSiteAddresses,
    WebSiteAddressDetailDto[] OutWebSiteAddresses,
    string? LastName = null,
    string? Alias = null,
    string? About = null,
    ImageCreateCommand? NewImage = null,
    UserBasicDto? User = null) : IUpdateCommand<Guid, PersonDetailDto>;
