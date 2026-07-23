using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Macroprograms.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjects.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjects.CQRS.Command.Create;

public record StrategicProjectCreateCommand(
    Guid Id,
    string Name, 
    int Priority, 
    bool IsEnabled, 
    Guid KindId, 
    Guid ProgramId, 
    string Objective,
    Clipped.SpecificObjectiveProjectClippedCreateCommand[] SpecificObjectives,
    Clipped.IndicatorClippedCreateCommand[] Indicators,
    MacroprogramBasicDto[] Macroprograms,
    string? Description = null) : ICreateCommand<StrategicProjectDetailDto>;