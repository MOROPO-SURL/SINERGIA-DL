using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Enumerations;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.OrganizationKind.DTOs;

public record OrganizationKindBasicDtoModel(Guid Id, string Name, DevelopmentActorProfileKind? DevelopmentActorProfileKind);