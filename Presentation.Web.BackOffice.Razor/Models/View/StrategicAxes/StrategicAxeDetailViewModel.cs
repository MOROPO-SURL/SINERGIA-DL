namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.StrategicAxes;

public record StrategicAxeDetailViewModel(int Id, string Name, bool IsArchived, bool IsEnabled, string? Description = null);