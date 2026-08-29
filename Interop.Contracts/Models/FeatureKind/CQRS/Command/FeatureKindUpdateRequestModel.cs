namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.FeatureKind.CQRS.Command;

public record FeatureKindUpdateRequestModel(Guid Id, string Name, string? Description = null);