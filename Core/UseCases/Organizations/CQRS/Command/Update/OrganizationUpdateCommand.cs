using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Organizations.CQRS.Command.Create.Clipped;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Organizations.CQRS.Command.Update.Clipped;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Organizations.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Persons.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Organizations.CQRS.Command.Update;

public record OrganizationUpdateCommand(
    Guid Id,
    string Name,
    bool IsEnabled,
    bool IsArchived,
    int Priority,
    Guid KindId,
    IEnumerable<EmailAddressDetailDto> InEmailAddresses,
    IEnumerable<EmailAddressDetailDto> OutEmailAddresses,
    IEnumerable<PhoneNumberDetailDto> InPhoneNumbers,
    IEnumerable<PhoneNumberDetailDto> OutPhoneNumbers,
    IEnumerable<PostalAddressDetailDto> InPostalAddresses,
    IEnumerable<PostalAddressDetailDto> OutPostalAddresses,
    IEnumerable<WebSiteAddressDetailDto> InWebSiteAddresses,
    IEnumerable<WebSiteAddressDetailDto> OutWebSiteAddresses,
    IEnumerable<OrganizationPersonRelationshipClippedCreateCommand> InPersonRelationships,
    IEnumerable<OrganizationPersonRelationshipClippedUpdateCommand> PatchPersonRelationships,
    IEnumerable<PersonBasicDto> OutPersonRelationships,
    string? About = null,
    ImageCreateCommand? NewImage = null) : IUpdateCommand<Guid, OrganizationDetailDto>;
