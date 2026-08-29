using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.FeatureKind.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Feature.DTOs;

public record FeatureDetailDtoModel(Guid Id, FeatureKindDetailDtoModel Kind, string Description, DateTime CreatedAt, DateTime? UpdatedAt = null);