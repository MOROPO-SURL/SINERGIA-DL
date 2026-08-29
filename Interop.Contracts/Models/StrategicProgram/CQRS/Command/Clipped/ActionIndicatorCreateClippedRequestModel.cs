using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.UnitMeasurement.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProgram.CQRS.Command.Clipped;

public record ActionIndicatorCreateClippedRequestModel(
    Guid Id, 
    string Name, 
    UnitMeasurementBasicDtoModel UnitMeasurement, 
    int Priority,
    IEnumerable<ActionIndicatorMilestoneCreateClippedRequestModel> Milestones,
    string? Alias = null);