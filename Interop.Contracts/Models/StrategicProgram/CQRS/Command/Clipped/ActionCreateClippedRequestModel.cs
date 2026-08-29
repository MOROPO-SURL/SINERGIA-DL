namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProgram.CQRS.Command.Clipped;

public record ActionCreateClippedRequestModel(
    Guid Id, 
    string Title, 
    int Priority,
    IEnumerable<ActionIndicatorCreateClippedRequestModel> Indicators,
    string? Description = null);