namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.TerritoryPotentials;

public record TerritoryPotentialDetailViewModel(Guid Id, string Title, bool IsArchived, DateTime CreatedAt, DateTime? UpdateAt = null, string? Description = null);