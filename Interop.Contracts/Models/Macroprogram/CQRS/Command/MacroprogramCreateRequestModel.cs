namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Macroprogram.CQRS.Command;

public record MacroprogramCreateRequestModel(int Index, string Title, string? Description = null);