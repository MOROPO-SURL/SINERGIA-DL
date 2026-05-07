using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjectKinds.DTOs;

public record StrategicProjectKindBasicDto(Guid Id, bool IsArchived, bool IsEnabled, string Name) : IDto;