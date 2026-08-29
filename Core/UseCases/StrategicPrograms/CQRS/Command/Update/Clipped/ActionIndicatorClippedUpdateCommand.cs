using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicPrograms.CQRS.Command.Create.Clipped;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicPrograms.DTOs.Clipped;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.UnitMeasurements.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicPrograms.CQRS.Command.Update.Clipped;

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