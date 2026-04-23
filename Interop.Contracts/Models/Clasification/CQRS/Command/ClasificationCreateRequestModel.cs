namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Clasification.CQRS.Command;

public record ClasificationCreateRequestModel(string Name, int Priority, string? Description = null);