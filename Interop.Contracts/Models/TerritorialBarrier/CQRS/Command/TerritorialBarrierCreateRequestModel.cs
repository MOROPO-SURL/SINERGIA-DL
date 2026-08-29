namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.TerritorialBarrier.CQRS.Command;

public record TerritorialBarrierCreateRequestModel(string Title, string? Description = null);