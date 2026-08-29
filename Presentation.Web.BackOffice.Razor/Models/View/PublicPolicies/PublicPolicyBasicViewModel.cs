using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PublicPolicyAggregate.Enumerations;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Models.View.PublicPolicies;

public record PublicPolicyBasicViewModel(Guid Id, string Title, PublicPolicyKind Kind, bool IsArchived);