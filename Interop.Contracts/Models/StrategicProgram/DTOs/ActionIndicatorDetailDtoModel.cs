using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.UnitMeasurement.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProgram.DTOs;

public record ActionIndicatorDetailDtoModel(
    Guid Id,
    string Name,
    UnitMeasurementBasicDtoModel UnitMeasurement,
    int Priority,
    ActionIndicatorMilestoneDetailDtoModel[] Milestones,
    string? Alias = null);