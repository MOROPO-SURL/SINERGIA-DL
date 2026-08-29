using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.UnitMeasurements.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicPrograms.CQRS.Command.Create.Clipped;

public record ActionIndicatorClippedCreateCommand(
    Guid Id, 
    string Name, 
    UnitMeasurementBasicDto UnitMeasurement,
    int Priority,
    IEnumerable<ActionIndicatorMilestoneClippedCreateCommand> Milestones,
    string? Alias = null, 
    string? Description = null);