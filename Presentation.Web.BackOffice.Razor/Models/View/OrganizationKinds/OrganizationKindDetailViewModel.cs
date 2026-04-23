namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.OrganizationKinds;

public record OrganizationKindDetailViewModel(Guid Id, string Name, bool IsEnabled, bool IsArchived, string? Description = null);