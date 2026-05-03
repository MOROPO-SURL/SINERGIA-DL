using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.TerritorialBarrier.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.UI.Presenters.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Models.Page.TerritorialBarrier;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.UI.Pages.TerritorialBarrier;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.UI.Pages;

public partial class TerritorialBarriersManagementPage : 
    BaseManagementEntityPage<TerritorialBarrierBasicDtoModel, TerritorialBarrierDetailDtoModel, TerritorialBarriersManagementPageModel, TerritorialBarrierConfigurationPageModel>, 
    IListItemsPageModelPresenter<TerritorialBarrierBasicDtoModel>,
    IManagementItemsPageModelPresenter
{
	public TerritorialBarriersManagementPage()
	{
		InitializeComponent();

        ConcreteBindingContext.BindPresenter(this as IListItemsPageModelPresenter<TerritorialBarrierBasicDtoModel>);
        ConcreteBindingContext.BindPresenter(this);
    }

    public Task PresentItemCreateUserInterfaceAsync()
    {
        Dispatcher.Dispatch(() => this.NavigationPushPageAsync(new TerritorialBarrierConfigurationPage(new TerritorialBarrierConfigurationPageModel(null, model => ConcreteBindingContext.LoadItems(true)))));

        return Task.CompletedTask;
    }

    public async Task PresentItemDetailUserInterfaceAsync(TerritorialBarrierBasicDtoModel model)
    {
        ConcreteBindingContext.IsBusy = true;

        TerritorialBarrierQueryApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        TerritorialBarrierDetailDtoModel result = await apiClient.GetAsync(model.Id);

        Dispatcher.Dispatch(() =>
        {
            ConcreteBindingContext.IsBusy = false;

            this.NavigationPushPageAsync(new TerritorialBarrierDetailPage(result));
        });
    }

    protected override CollectionView GetItemsCollectionView() => ItemsCollectionView;

    protected override double MeasureCollectionViewCellHeight(double width) => Constants.CardViewSizeConstants.TERRITORIALBARRIER_DEFAULT_CARD_VIEW_HEIGHT;
}