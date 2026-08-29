namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Objective.CQRS.Command;

public record ObjectiveProjectionUpdateRequestModel(Guid Id, int Index, string Title, string? Description = null);