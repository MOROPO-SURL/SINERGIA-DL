namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Objective.DTOs;

public record class ObjectiveDetailDtoModel(Guid Id, int Index, string Title, ObjectiveChallengeDetailDtoModel[] Challanges, ObjectiveProjectionDetailDtoModel[] Projections, ObjectiveActionDetailDtoModel[] Actions, string? Description = null);