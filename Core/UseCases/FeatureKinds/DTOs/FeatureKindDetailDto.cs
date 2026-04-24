using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.FeatureKinds.DTOs;

public record FeatureKindDetailDto(Guid Id, bool IsEnabled, string Name, int Priority, string? Description = null) : IDetailDto;
