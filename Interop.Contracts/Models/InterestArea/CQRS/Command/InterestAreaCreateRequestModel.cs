namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.InterestArea.CQRS.Command;

public record InterestAreaCreateRequestModel(Guid Id, string Name, string? Description, bool IsEnable);

