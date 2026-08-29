namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Models.View.FeatureKinds;

public record FeatureKindDetailViewModel(Guid Id, string Name, bool IsEnabled, string? Description = null);