using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.FeatureKinds.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Features.DTOs;

public record FeatureBasicDto(Guid Id, FeatureKindBasicDto Kind, string Description) : IDto;