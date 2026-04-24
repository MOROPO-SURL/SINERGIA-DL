using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.FeatureKind.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Feature.DTOs;

public record FeatureDetailDtoModel(Guid Id, FeatureKindDetailDtoModel Kind, string Description, DateTime CreatedAt, DateTime? UpdatedAt = null);