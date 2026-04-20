namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Objective.CQRS.Command;

public record ObjectiveUpdateRequestModel(Guid Id, int Index, string Title, ObjectiveChallangeUpdateRequestModel[] Challanges, ObjectiveProjectionUpdateRequestModel[] Projections, ObjectiveActionUpdateRequestModel[] Actions, string? Description = null);