using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Organizations.CQRS.Command.Create.Clipped;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Organizations.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationAggregate.Enumerations;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Organizations.CQRS.Command.Create;

public record OrganizationCreateCommand(
    string Name,
    bool IsEnabled,
    bool IsArchived,
    int Priority,
    Guid OrganizationKindId,
    IEnumerable<EmailAddressDetailDto> EmailAddresses,
    IEnumerable<PhoneNumberDetailDto> PhoneNumbers,
    IEnumerable<PostalAddressDetailDto> PostalAddresses,
    IEnumerable<WebSiteAddressDetailDto> WebSiteAddresses,
    IEnumerable<OrganizationPersonRelationshipClippedCreateCommand> PersonRelationships,
    DevelopmentActorProfileKind? DevelopmentActorProfileKind = null,
    string? About = null,
    ImageCreateCommand? Image = null) : ICreateCommand<OrganizationDetailDto>;
