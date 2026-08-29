namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Models.View.Macroprograms;

public record MacroprogramDetailViewModel(Guid Id, int Index, string Title, bool IsArchived, DateTime CreatedAt, DateTime? UpdatedAt = null, string? Description = null);