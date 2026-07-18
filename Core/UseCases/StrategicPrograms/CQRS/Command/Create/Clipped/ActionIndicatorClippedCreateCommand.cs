using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.UnitMeasurements.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.CQRS.Command.Create.Clipped;

public record ActionIndicatorClippedCreateCommand(
    Guid Id, 
    string Name, 
    UnitMeasurementBasicDto UnitMeasurement, 
    string? Alias = null, 
    string? Description = null);