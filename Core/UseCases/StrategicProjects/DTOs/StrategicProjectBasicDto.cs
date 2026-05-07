using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjectKinds.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjects.DTOs;

public record StrategicProjectBasicDto(Guid Id, string Name, bool IsEnabled, bool IsArchived, StrategicProjectKindBasicDto Kind) : IDto;