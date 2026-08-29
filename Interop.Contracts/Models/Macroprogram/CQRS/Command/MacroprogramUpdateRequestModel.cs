namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Macroprogram.CQRS.Command;

public record MacroprogramUpdateRequestModel(Guid Id, int Index, string Title, string? Description = null);