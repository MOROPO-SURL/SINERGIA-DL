using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.FeatureKinds.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Features.DTOs;

public record FeatureDetailDto(Guid Id, FeatureKindBasicDto Kind, DateTime CreatedAt, string Description, DateTime? UpdateAt = null) : IDetailDto;
