using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.UnitMeasurement.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProject.CQRS.Command.Clipped
{
    public record IndicatorCreateClippedRequestModel(
    Guid Id,
    string Name,
    UnitMeasurementBasicDtoModel UnitMeasurement,
    int Priority,
    IEnumerable<IndicatorMilestoneCreateClippedRequestModel> Milestones,
    string? Alias = null);
}
