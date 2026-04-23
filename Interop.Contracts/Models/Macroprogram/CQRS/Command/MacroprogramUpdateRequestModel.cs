namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Macroprogram.CQRS.Command;

public record MacroprogramUpdateRequestModel(Guid Id, string Title, string? Description, int Index);

