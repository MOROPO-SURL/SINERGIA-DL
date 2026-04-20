namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Objective.CQRS.Command;

public record ObjectiveCreateRequestModel(int Index, string Title, ObjectiveChallangeCreateRequestModel[] Challanges, ObjectiveProjectionCreateRequestModel[] Projections, ObjectiveActionCreateRequestModel[] Actions, string? Description = null);