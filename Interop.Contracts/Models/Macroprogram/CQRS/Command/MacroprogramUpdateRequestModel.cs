namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Macroprogram.CQRS.Command;

public record MacroprogramUpdateRequestModel(Guid Id, int Index, string Title, string? Description = null);