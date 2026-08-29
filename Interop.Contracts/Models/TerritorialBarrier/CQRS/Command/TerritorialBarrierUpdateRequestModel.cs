namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.TerritorialBarrier.CQRS.Command;

public record TerritorialBarrierUpdateRequestModel(Guid Id, string Title, string? Description = null);