namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.TerritorialBarrier.CQRS.Command;

public record TerritorialBarrierCreateRequestModel(string Title, string? Description = null);