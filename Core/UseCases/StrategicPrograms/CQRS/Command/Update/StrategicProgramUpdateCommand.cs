using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.CQRS.Command.Create.Addon;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.CQRS.Command.Update;

public record StrategicProgramUpdateCommand(
    Guid Id, 
    string Name, 
    int Priority, 
    bool IsEnabled,
    ProgramObjectiveAddonCreateCommand[] InObjectives,
    ProgramObjectiveAddonUpdateCommand[] PatchObjectives,
    ProgramObjectiveDetailDto[] OutObjectives,
    ProgramActionAddonCreateCommand[] InActions,
    ProgramActionAddonUpdateCommand[] PatchActions,
    ProgramActionDetailDto[] OutActions, 
    string? Description = null) : IUpdateCommand<Guid, StrategicProgramDetailDto>;