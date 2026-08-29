using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectKinds.DTOs;

public record StrategicProjectKindBasicDto(Guid Id, bool IsArchived, bool IsEnabled, string Name) : IDto;