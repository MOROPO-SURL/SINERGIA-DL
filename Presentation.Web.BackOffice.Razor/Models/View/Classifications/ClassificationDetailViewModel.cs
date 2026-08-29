namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Models.View.Classifications;

public record ClassificationDetailViewModel(Guid Id, string Name, bool IsArchived, bool IsEnabled, int Priority, string? Description = null);