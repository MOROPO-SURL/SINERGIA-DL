using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.TerritorialBarrier.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.UI.Presenters.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Models.Page.TerritorialBarrier;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.UI.Pages.TerritorialBarrier;

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