namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.TerritorialBarrier.CQRS.Command;

public record TerritorialBarrierUpdateRequestModel(Guid Id, string Title, string? Description = null);