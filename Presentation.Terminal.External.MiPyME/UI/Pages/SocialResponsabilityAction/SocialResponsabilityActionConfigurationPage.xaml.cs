using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.SocialResponsabilityAction.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Presenters;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.MiPyME.Models.Page.SocialResponsabilityAction;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.MiPyME.UI.Pages.SocialResponsabilityAction;

public partial class SocialResponsabilityActionConfigurationPage : BaseConfigurationEntityPage<SRLSocialResponsabilityActionDetailDtoModel, SRLSocialResponsabilityActionDetailDtoModel, SocialResponsabilityActionConfigurationPageModel>
{
    public SocialResponsabilityActionConfigurationPage(SocialResponsabilityActionConfigurationPageModel bindingContextModel) : base(bindingContextModel)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Acción de Responsabilidad Social";

    private void AddImageButton_Clicked(object sender, EventArgs eventArgs)
    {
        ImagePickPresenter.Instance.BeginImagePickAsync(this, ConcreteBindingContext.ImagePickSuccess_Callback);
    }
}