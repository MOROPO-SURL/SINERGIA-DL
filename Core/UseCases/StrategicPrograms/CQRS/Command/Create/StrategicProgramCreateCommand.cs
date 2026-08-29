using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Macroprograms.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Organizations.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicPrograms.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicPrograms.CQRS.Command.Create;

public record StrategicProgramCreateCommand(
    Guid Id,
    string Name,
    int Priority, 
    bool IsEnabled,
    Guid LineId,
    Guid CoordinatorId,
    string Objective,
    Clipped.SpecificObjectiveClippedCreateCommand[] SpecificObjectives,
    Clipped.ImpactClippedCreateCommand[] Impacts,
    Clipped.ActionClippedCreateCommand[] Actions,
    OrganizationBasicDto[] Organizations,
    MacroprogramBasicDto[] Macroprograms,
    string? Description = null) : ICreateCommand<StrategicProgramDetailDto>;