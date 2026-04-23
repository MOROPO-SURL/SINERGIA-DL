namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.OrganizationKinds.CQRS.Command;

public record OrganizationKindUpdateRequestModel(Guid Id, string Name, string? Description = null);