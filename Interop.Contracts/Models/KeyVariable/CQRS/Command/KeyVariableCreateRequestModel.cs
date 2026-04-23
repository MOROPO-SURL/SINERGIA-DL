namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.KeyVariable.CQRS.Command;

public record KeyVariableCreateRequestModel(string Name, int Priority, string? Alias = null, string? Description = null);