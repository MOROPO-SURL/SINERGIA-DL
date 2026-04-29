using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PublicPolicyAggregate.Enumerations;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.PublicPolicies;

public record PublicPolicyBasicViewModel(Guid Id, string Title, PublicPolicyKind Kind, bool IsArchived);