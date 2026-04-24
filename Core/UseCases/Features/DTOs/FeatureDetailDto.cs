using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.FeatureKinds.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Features.DTOs;

public record FeatureDetailDto(Guid Id, FeatureKindBasicDto Kind, DateTime CreatedAt, string Description, DateTime? UpdateAt = null) : IDetailDto;
