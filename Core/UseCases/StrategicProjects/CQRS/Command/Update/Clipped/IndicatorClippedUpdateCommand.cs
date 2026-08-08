using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjects.CQRS.Command.Create.Clipped;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjects.DTOs.Clipped;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.UnitMeasurements.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjects.CQRS.Command.Update.Clipped;

public record IndicatorClippedUpdateCommand(
    Guid Id,
    string Name,
    UnitMeasurementBasicDto UnitMeasurement,
    int Priority,
    IEnumerable<IndicatorMilestoneClippedCreateCommand> InMilestones,
    IEnumerable<IndicatorMilestoneClippedUpdateCommand> PatchMilestones,
    IEnumerable<IndicatorMilestoneClippedDetailDto> OutMilestones,
    string? Alias = null,
    string? Description = null);
