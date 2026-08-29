using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.TerritorialBarrier.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.TerritorialBarrier;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Presenters.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.TerritorialBarrier;

public partial class TerritorialBarrierDetailPage : BaseDetailEntityPage<TerritorialBarrierDetailDtoModel, TerritorialBarrierDetailPageModel>, IDetailItemPageModelPresenter<TerritorialBarrierDetailDtoModel>
{
    public TerritorialBarrierDetailPage(TerritorialBarrierDetailDtoModel model) : base(new TerritorialBarrierDetailPageModel(model))
    {
        InitializeComponent();

        ConcreteBindingContext.BindPresenter(this);
    }

    public Task PresentItemModifyUserInterfaceAsync(TerritorialBarrierDetailDtoModel model, Action<TerritorialBarrierDetailDtoModel> configurationSuccessCallbackAction)
    {
        Dispatcher.Dispatch(() => this.NavigationPushPageAsync(new TerritorialBarrierConfigurationPage(new TerritorialBarrierConfigurationPageModel(model, configurationSuccessCallbackAction))));

        return Task.CompletedTask;
    }
}