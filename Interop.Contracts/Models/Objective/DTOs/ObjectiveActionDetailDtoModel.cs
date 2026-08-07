namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Objective.DTOs;

public record ObjectiveActionDetailDtoModel(
    Guid Id, 
    int Index, 
    string Title,
    ObjectiveActionIndicatorDetailDtoModel[] Indicators,
    string? Description = null);