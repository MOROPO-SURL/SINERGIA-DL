using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.TerritoryPotential.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.UI.Presenters.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Models.Page.TerritoryPotential;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.UI.Pages.TerritoryPotential;

public partial class TerritoryPotentialDetailPage : BaseDetailEntityPage<TerritoryPotentialDetailDtoModel, TerritoryPotentialDetailPageModel>, IDetailItemPageModelPresenter<TerritoryPotentialDetailDtoModel>
{
    public TerritoryPotentialDetailPage(TerritoryPotentialDetailDtoModel model) : base(new TerritoryPotentialDetailPageModel(model))
    {
        InitializeComponent();

        ConcreteBindingContext.BindPresenter(this);
    }

    public Task PresentItemModifyUserInterfaceAsync(TerritoryPotentialDetailDtoModel model, Action<TerritoryPotentialDetailDtoModel> configurationSuccessCallbackAction)
    {
        Dispatcher.Dispatch(() => this.NavigationPushPageAsync(new TerritoryPotentialConfigurationPage(new TerritoryPotentialConfigurationPageModel(model, configurationSuccessCallbackAction))));

        return Task.CompletedTask;
    }
}