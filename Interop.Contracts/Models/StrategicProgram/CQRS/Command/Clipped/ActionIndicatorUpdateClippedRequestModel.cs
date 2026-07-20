using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProgram.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.UnitMeasurement.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProgram.CQRS.Command.Clipped;

public record ActionIndicatorUpdateClippedRequestModel(
    Guid Id, 
    string Name, 
    UnitMeasurementBasicDtoModel UnitMeasurement, 
    int Priority,
    IEnumerable<ActionIndicatorMilestoneCreateClippedRequestModel> InMilestones,
    IEnumerable<ActionIndicatorMilestoneUpdateClippedRequestModel> PatchMilestones,
    IEnumerable<ActionIndicatorMilestoneDetailDtoModel> OutMilestones,
    string? Alias = null);