using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Persons.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Users.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PersonAggregate.Enumerations;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Persons.CQRS.Command.Create;

public record PersonCreateCommand(
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
    ImageCreateCommand? NewImage = null,
    UserBasicDto? User = null) : ICreateCommand<PersonDetailDto>;
