using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.SocialSupportDemand.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Presenters;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.SocialSupportDemand.Configuration;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.SocialSupportDemand.Configuration;

public partial class SocialSupportDemandConfigurationPage : BaseConfigurationEntityPage<SocialSupportDemandDetailDtoModel, SocialSupportDemandDetailDtoModel, SocialSupportDemandConfigurationPageModel>
{
    public SocialSupportDemandConfigurationPage(SocialSupportDemandConfigurationPageModel bindingContextModel) : base(bindingContextModel)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Prioridad de asistencia social";

    private void AddImageButton_Clicked(object sender, EventArgs eventArgs)
    {
        ImagePickPresenter.Instance.BeginImagePickAsync(this, ConcreteBindingContext.ImagePickSuccess_Callback);
    }
}