using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Macroprograms.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjects.CQRS.Command.Create.Clipped;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjects.CQRS.Command.Update.Clipped;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjects.DTOs.Clipped;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjects.CQRS.Command.Update;

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