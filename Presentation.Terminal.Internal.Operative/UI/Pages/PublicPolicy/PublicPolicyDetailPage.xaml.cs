using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.PublicPolicy.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.PublicPolicy;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Presenters.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.PublicPolicy;

public partial class PublicPolicyDetailPage : BaseDetailEntityPage<PublicPolicyDetailDtoModel, PublicPolicyDetailPageModel>, IDetailItemPageModelPresenter<PublicPolicyDetailDtoModel>
{
    public PublicPolicyDetailPage(PublicPolicyDetailDtoModel model) : base(new PublicPolicyDetailPageModel(model))
    {
        InitializeComponent();

        ConcreteBindingContext.BindPresenter(this);
    }

    public Task PresentItemModifyUserInterfaceAsync(PublicPolicyDetailDtoModel model, Action<PublicPolicyDetailDtoModel> configurationSuccessCallbackAction)
    {
        Dispatcher.Dispatch(() => this.NavigationPushPageAsync(new PublicPolicyConfigurationPage(new PublicPolicyConfigurationPageModel(model, configurationSuccessCallbackAction))));

        return Task.CompletedTask;
    }
}