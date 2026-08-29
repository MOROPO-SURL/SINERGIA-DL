namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Models.View.TerritorialBarriers;

public record TerritorialBarrierDetailViewModel(Guid Id, string Title, bool IsArchived, DateTime CreatedAt, DateTime? UpdateAt = null, string? Description = null);