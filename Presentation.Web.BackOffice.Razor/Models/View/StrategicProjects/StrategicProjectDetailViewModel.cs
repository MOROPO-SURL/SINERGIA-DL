namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.StrategicProjects;

public record StrategicProjectDetailViewModel(Guid Id, string Name, bool IsArchived, bool IsEnabled, string? Description = null);