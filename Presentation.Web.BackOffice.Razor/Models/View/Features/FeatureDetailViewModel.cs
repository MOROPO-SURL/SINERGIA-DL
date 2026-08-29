using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Models.View.FeatureKinds;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Models.View.Features;

public record FeatureDetailViewModel(Guid Id, FeatureKindBasicViewModel Kind, string Description, DateTime CreatedAt, DateTime? UpdateAt = null);