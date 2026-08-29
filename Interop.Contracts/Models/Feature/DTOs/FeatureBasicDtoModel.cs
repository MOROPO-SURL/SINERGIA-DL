using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.FeatureKind.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Feature.DTOs;

public record FeatureBasicDtoModel(Guid Id, FeatureKindBasicDtoModel Kind, string Description);