using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Organizations.CQRS.Command.Create.Clipped;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Organizations.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Organizations.CQRS.Command.Create;

public record OrganizationCreateCommand(
    string Name,
    bool IsEnabled,
    bool IsArchived,
    int Priority,
    Guid KindId,
    IEnumerable<EmailAddressDetailDto> EmailAddresses,
    IEnumerable<PhoneNumberDetailDto> PhoneNumbers,
    IEnumerable<PostalAddressDetailDto> PostalAddresses,
    IEnumerable<WebSiteAddressDetailDto> WebSiteAddresses,
    IEnumerable<OrganizationPersonRelationshipClippedCreateCommand> PersonRelationships,
    string? About = null,
    ImageCreateCommand? NewImage = null) : ICreateCommand<OrganizationDetailDto>;
