using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.SocialSupportDemand.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Presenters.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.SocialSupportDemand.Configuration;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.SocialSupportDemand.Detail;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.SocialSupportDemand.Configuration;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Validators;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.SocialSupportDemand.Detail;

public partial class SocialSupportDemandDetailPage : BaseDetailEntityPage<SocialSupportDemandDetailDtoModel, SocialSupportDemandDetailPageModel>, IDetailItemPageModelPresenter<SocialSupportDemandDetailDtoModel>
{
    public SocialSupportDemandDetailPage(SocialSupportDemandDetailDtoModel model) : base(new SocialSupportDemandDetailPageModel(model))
    {
        InitializeComponent();

        ConcreteBindingContext.BindPresenter(this);
    }

    public Task PresentItemModifyUserInterfaceAsync(SocialSupportDemandDetailDtoModel model, Action<SocialSupportDemandDetailDtoModel> configurationSuccessCallbackAction)
    {
        Dispatcher.Dispatch(() => this.NavigationPushPageAsync(new SocialSupportDemandConfigurationPage(new SocialSupportDemandConfigurationPageModel(model, configurationSuccessCallbackAction, new SocialSupportDemandConfigurationValidator()))));

        return Task.CompletedTask;
    }
}