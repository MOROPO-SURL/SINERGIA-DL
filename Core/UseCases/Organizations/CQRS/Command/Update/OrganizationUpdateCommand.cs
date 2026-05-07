using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Organizations.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Organizations.CQRS.Command.Update;

public record OrganizationUpdateCommand(
    Guid Id,
    string Name,
    bool IsEnabled,
    bool IsArchived,
    int Priority,
    Guid OrganizationKindId,
    EmailAddressDetailDto[] InEmailAddresses,
    EmailAddressDetailDto[] OutEmailAddresses,
    PhoneNumberDetailDto[] InPhoneNumbers,
    PhoneNumberDetailDto[] OutPhoneNumbers,
    PostalAddressDetailDto[] InPostalAddresses,
    PostalAddressDetailDto[] OutPostalAddresses,
    WebSiteAddressDetailDto[] InWebSiteAddresses,
    WebSiteAddressDetailDto[] OutWebSiteAddresses,
    string? About = null,
    ImageCreateCommand? Image = null) : IUpdateCommand<Guid, OrganizationDetailDto>;
