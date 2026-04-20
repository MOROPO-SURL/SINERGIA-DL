namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Objective.DTOs;

public record class ObjectiveDetailDtoModel(Guid Id, int Index, string Title, ObjectiveChallangeDetailDtoModel[] Challanges, ObjectiveProyectionDetailDtoModel[] Proyections, ObjectiveActionDetailDtoModel[] Actions, string? Description = null);