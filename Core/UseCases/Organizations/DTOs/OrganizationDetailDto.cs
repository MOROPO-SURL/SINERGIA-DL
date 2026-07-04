using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OrganizationKinds.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Persons.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationAggregate.Enumerations;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Organizations.DTOs;

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
    DevelopmentActorProfileKind? DevelopmentActorProfileKind = null,
    string? Alias = null, 
    string? About = null, 
    ImageBasicDto? Image = null) : IDetailDto;
