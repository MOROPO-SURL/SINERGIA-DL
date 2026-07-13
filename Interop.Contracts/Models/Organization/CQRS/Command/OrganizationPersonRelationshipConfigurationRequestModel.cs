using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Person.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Organization.CQRS.Command;

public record OrganizationPersonRelationshipConfigurationRequestModel(PersonBasicDtoModel Person, bool IsRepresentative);