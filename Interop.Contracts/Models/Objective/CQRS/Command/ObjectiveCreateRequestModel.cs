namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Objective.CQRS.Command;

public record ObjectiveCreateRequestModel(
    int Index, 
    string Title, 
    ObjectiveChallengeCreateRequestModel[] Challenges, 
    ObjectiveProjectionCreateRequestModel[] Projections, 
    ObjectiveActionCreateRequestModel[] Actions, 
    string? Description = null);