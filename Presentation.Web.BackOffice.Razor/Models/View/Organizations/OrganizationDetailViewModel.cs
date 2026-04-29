namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.Organizations;

public record OrganizationDetailViewModel(Guid Id, string Name, bool IsArchived, bool IsEnabled, int Priority, string? About = null);