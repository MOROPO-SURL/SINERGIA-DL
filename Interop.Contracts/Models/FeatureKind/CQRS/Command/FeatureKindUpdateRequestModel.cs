namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.FeatureKind.CQRS.Command;

public record FeatureKindUpdateRequestModel(Guid Id, string Name, string? Description = null);