using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.PublicPolicy.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.PublicPolicy;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.PublicPolicy;

public partial class PublicPolicyConfigurationPage : BaseConfigurationEntityPage<PublicPolicyDetailDtoModel, PublicPolicyDetailDtoModel, PublicPolicyConfigurationPageModel>
{
    public PublicPolicyConfigurationPage(PublicPolicyConfigurationPageModel bindingContextModel) : base(bindingContextModel)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Política pública";
}