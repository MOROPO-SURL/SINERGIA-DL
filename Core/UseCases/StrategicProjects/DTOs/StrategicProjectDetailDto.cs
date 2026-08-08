using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Macroprograms.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjectKinds.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjects.DTOs.Clipped;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjects.DTOs;

public record StrategicProjectDetailDto(
    Guid Id, 
    string Name, 
    int Priority, 
    bool IsEnabled, 
    StrategicProjectKindBasicDto Kind, 
    StrategicProgramBasicDto Program, 
    string Objective,
    SpecificObjectiveProjectClippedDetailDto[] SpecificObjectives,
    MacroprogramBasicDto[] Macroprograms,
    IndicatorClippedDetailDto[] Indicators,
    string? Description = null) : IDetailDto;