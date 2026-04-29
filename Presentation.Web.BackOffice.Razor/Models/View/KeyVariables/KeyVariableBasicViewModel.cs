namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.KeyVariables;

public record KeyVariableBasicViewModel(Guid Id, string Name, bool IsArchived, string? Alias = null);