using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.UnitMeasurements.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjects.CQRS.Command.Create.Clipped;

public record IndicatorClippedCreateCommand(
    Guid Id,
    string Name,
    UnitMeasurementBasicDto UnitMeasurement,
    int Priority,
    IEnumerable<IndicatorMilestoneClippedCreateCommand> Milestones,
    string? Alias = null,
    string? Description = null);
