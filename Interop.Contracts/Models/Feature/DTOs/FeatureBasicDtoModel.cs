using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.FeatureKind.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Feature.DTOs;

public record FeatureBasicDtoModel(Guid Id, FeatureKindBasicDtoModel Kind, string Description);