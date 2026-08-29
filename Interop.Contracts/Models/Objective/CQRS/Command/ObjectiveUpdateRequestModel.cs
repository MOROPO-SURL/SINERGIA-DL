using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Objective.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Objective.CQRS.Command;

public record ObjectiveUpdateRequestModel(
    Guid Id, 
    int Index, 
    string Title,
    ObjectiveChallengeCreateRequestModel[] InChallenges,
    ObjectiveChallengeUpdateRequestModel[] PatchChallenges,
    ObjectiveChallengeDetailDtoModel[] OutChallenges,
    ObjectiveProjectionCreateRequestModel[] InProjections,
    ObjectiveProjectionUpdateRequestModel[] PatchProjections,
    ObjectiveProjectionDetailDtoModel[] OutProjections,
    ObjectiveActionCreateRequestModel[] InActions,
    ObjectiveActionUpdateRequestModel[] PatchActions,
    ObjectiveActionDetailDtoModel[] OutActions,
    string? Description = null);