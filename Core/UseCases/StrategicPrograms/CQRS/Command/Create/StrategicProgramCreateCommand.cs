using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.CQRS.Command.Create.Addon;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.CQRS.Command.Create;

public record StrategicProgramCreateCommand(
    Guid Id,
    string Name,
    int Priority, 
    bool IsEnabled,
    Guid LineId,
    Guid CoordinatorId,
    string Objective,
    ProgramObjectiveAddonCreateCommand[] Objectives,
    ProgramActionAddonCreateCommand[] Actions,
    string? Description = null) : ICreateCommand<StrategicProgramDetailDto>;