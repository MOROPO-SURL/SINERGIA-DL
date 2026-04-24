namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Feature.CQRS.Command;

public record FeatureUpdateRequestModel(Guid Id, Guid KindId, string Description);