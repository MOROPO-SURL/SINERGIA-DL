namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.StrategicProjectKinds;

public record StrategicProjectKindDetailViewModel(Guid Id, string Name, bool IsEnabled, bool IsArchived, string? Description = null);