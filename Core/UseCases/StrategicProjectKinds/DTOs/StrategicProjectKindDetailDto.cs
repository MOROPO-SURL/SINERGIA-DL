using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectKinds.DTOs;

public record StrategicProjectKindDetailDto(Guid Id, bool IsEnabled, bool IsArchived, string Name, int Priority, string? Description = null) : IDetailDto;