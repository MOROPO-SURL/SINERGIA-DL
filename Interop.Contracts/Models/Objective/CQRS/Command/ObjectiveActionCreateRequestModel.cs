namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Objective.CQRS.Command;

public record ObjectiveActionCreateRequestModel(
    Guid Id, 
    int Index, 
    string Title,
    IEnumerable<ObjectiveActionIndicatorCreateRequestModel> Indicators,
    string? Description = null);