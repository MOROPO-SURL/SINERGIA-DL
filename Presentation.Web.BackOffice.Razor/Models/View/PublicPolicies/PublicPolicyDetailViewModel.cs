using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PublicPolicyAggregate.Enumerations;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Models.View.PublicPolicies;

public record PublicPolicyDetailViewModel(Guid Id, string Title, PublicPolicyKind Kind, bool IsArchived, DateTime CreatedAt, DateTime? UpdateAt = null, string? Description = null);