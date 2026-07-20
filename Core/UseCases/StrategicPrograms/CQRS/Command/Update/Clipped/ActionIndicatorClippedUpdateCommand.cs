using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.CQRS.Command.Create.Clipped;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.DTOs.Clipped;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.UnitMeasurements.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.CQRS.Command.Update.Clipped;

public record ActionIndicatorClippedUpdateCommand(
    Guid Id, 
    string Name, 
    UnitMeasurementBasicDto UnitMeasurement,
    int Priority,
    IEnumerable<ActionIndicatorMilestoneClippedCreateCommand> InMilestones,
    IEnumerable<ActionIndicatorMilestoneClippedUpdateCommand> PatchMilestones,
    IEnumerable<ActionIndicatorMilestoneClippedDetailDto> OutMilestones,
    string? Alias = null,
    string? Description = null);