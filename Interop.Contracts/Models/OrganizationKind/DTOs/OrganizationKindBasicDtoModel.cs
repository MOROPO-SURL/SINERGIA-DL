using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Enumerations;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.OrganizationKind.DTOs;

public record OrganizationKindBasicDtoModel(Guid Id, string Name, DevelopmentActorProfileKind? DevelopmentActorProfileKind);