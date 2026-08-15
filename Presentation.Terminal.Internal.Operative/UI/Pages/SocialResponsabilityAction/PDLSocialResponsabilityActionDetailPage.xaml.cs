using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.SocialResponsabilityAction.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.SocialResponsabilityAction;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.SocialResponsabilityAction;

public partial class PDLSocialResponsabilityActionDetailPage : BaseDetailEntityPage<PDLSocialResponsabilityActionDetailDtoModel, PDLSocialResponsabilityActionDetailPageModel>
{
    public PDLSocialResponsabilityActionDetailPage(PDLSocialResponsabilityActionDetailDtoModel model) : base(new PDLSocialResponsabilityActionDetailPageModel(model))
    {
        InitializeComponent();
    }
}