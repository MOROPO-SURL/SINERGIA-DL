namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Models.View.KeyVariables;

public record KeyVariableDetailViewModel(Guid Id, string Name, bool IsArchived, int Priority, string? Alias = null, string? Description = null);