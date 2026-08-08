using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Macroprograms.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjects.CQRS.Command.Create.Clipped;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjects.CQRS.Command.Update.Clipped;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjects.DTOs.Clipped;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjects.CQRS.Command.Update;

public record StrategicProjectUpdateCommand(
    Guid Id, 
    string Name, 
    int Priority, 
    bool IsEnabled, 
    Guid KindId, 
    Guid ProgramId, 
    string Objective,
    SpecificObjectiveProjectClippedCreateCommand[] InSpecificObjectives,
    SpecificObjectiveProjectClippedUpdateCommand[] PatchSpecificObjectives,
    SpecificObjectiveProjectClippedDetailDto[] OutSpecificObjectives,
    IndicatorClippedCreateCommand[] InIndicators,
    IndicatorClippedUpdateCommand[] PatchIndicators,
    IndicatorClippedDetailDto[] OutIndicators,
    MacroprogramBasicDto[] InMacroprograms,
    MacroprogramBasicDto[] OutMacroprograms,
    string? Description = null) : IUpdateCommand<Guid, DTOs.StrategicProjectDetailDto>;