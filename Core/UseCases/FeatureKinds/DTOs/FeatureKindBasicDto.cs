using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.FeatureKinds.DTOs;

public record FeatureKindBasicDto(Guid Id, bool IsEnabled, string Name) : IDto;