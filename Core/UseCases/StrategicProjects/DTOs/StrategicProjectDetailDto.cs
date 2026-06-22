using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjectKinds.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjects.DTOs;

public record StrategicProjectDetailDto(Guid Id, string Name, int Priority, bool IsEnabled, StrategicProjectKindBasicDto Kind, StrategicProgramBasicDto Program, string Objective, string? Description = null) : IDetailDto;