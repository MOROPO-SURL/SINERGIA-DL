using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.PublicPolicy.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Models.Page.PublicPolicy;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.UI.Pages.PublicPolicy;

public partial class PublicPolicyConfigurationPage : BaseConfigurationEntityPage<PublicPolicyBasicDtoModel, PublicPolicyDetailDtoModel, PublicPolicyConfigurationPageModel>
{
    public PublicPolicyConfigurationPage(PublicPolicyConfigurationPageModel bindingContextModel) : base(bindingContextModel)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Política pública";
}