namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.FeatureKind.DTOs;

public record FeatureKindDetailDtoModel(Guid Id, string Name, bool IsEnabled, string? Description = null);