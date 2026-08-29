namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Objective.DTOs;

public record ObjectiveActionDetailDtoModel(
    Guid Id, 
    int Index, 
    string Title,
    ObjectiveActionIndicatorDetailDtoModel[] Indicators,
    string? Description = null);