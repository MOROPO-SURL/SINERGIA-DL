using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Person.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Organization.CQRS.Command;

public record OrganizationPersonRelationshipConfigurationRequestModel(PersonBasicDtoModel Person, bool IsRepresentative);