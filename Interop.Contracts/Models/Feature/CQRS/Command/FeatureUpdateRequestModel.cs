namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Feature.CQRS.Command;

public record FeatureUpdateRequestModel(Guid Id, Guid KindId, string Description);