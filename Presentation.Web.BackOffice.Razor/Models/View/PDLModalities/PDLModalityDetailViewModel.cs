namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.PDLModalities;

public record PDLModalityDetailViewModel(Guid Id, bool IsEnabled, int Priority, string Name, string? Description = null);