using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.UnitMeasurements.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.CQRS.Command.Update.Clipped;

public record ActionIndicatorClippedUpdateCommand(
    Guid Id, 
    string Name, 
    UnitMeasurementBasicDto UnitMeasurement, 
    string? Alias = null, 
    string? Description = null);