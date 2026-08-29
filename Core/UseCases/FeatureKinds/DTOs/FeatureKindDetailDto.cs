using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.FeatureKinds.DTOs;

public record FeatureKindDetailDto(Guid Id, bool IsEnabled, string Name, int Priority, string? Description = null) : IDetailDto;
