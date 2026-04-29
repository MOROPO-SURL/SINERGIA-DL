namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.StrategicLines;

public record StrategicLineDetailViewModel(int Id, int AxeId, string Name, bool IsArchived, bool IsEnabled, string? Description = null);