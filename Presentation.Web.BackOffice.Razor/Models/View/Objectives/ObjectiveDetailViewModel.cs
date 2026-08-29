namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Models.View.Objectives;

public record ObjectiveDetailViewModel(Guid Id, int Index, string Title, bool IsArchived, bool IsEnabled, DateTime CreatedAt, DateTime? UpdatedAt = null, string? Description = null);