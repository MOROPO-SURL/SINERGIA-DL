using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.TerritoryPotential.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.UI.Presenters.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Models.Page.TerritoryPotential;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.UI.Pages.TerritoryPotential;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.UI.Pages;

public partial class TerritoryPotentialsManagementPage : 
    BaseManagementEntityPage<TerritoryPotentialBasicDtoModel, TerritoryPotentialDetailDtoModel, TerritoryPotentialsManagementPageModel, TerritoryPotentialConfigurationPageModel>, 
    IListItemsPageModelPresenter<TerritoryPotentialBasicDtoModel>,
    IManagementItemsPageModelPresenter
{
	public TerritoryPotentialsManagementPage()
	{
		InitializeComponent();

        ConcreteBindingContext.BindPresenter(this as IListItemsPageModelPresenter<TerritoryPotentialBasicDtoModel>);
        ConcreteBindingContext.BindPresenter(this);
    }

    public Task PresentItemCreateUserInterfaceAsync()
    {
        Dispatcher.Dispatch(() => this.NavigationPushPageAsync(new TerritoryPotentialConfigurationPage(new TerritoryPotentialConfigurationPageModel(null, model => ConcreteBindingContext.LoadItems(true)))));

        return Task.CompletedTask;
    }

    public async Task PresentItemDetailUserInterfaceAsync(TerritoryPotentialBasicDtoModel model)
    {
        ConcreteBindingContext.IsBusy = true;

        TerritoryPotentialQueryApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        TerritoryPotentialDetailDtoModel result = await apiClient.GetAsync(model.Id);

        Dispatcher.Dispatch(() =>
        {
            ConcreteBindingContext.IsBusy = false;

            this.NavigationPushPageAsync(new TerritoryPotentialDetailPage(result));
        });
    }

    protected override CollectionView GetItemsCollectionView() => ItemsCollectionView;

    protected override double MeasureCollectionViewCellHeight(double width) => Constants.CardViewSizeConstants.TERRITORYPORTENTIAL_DEFAULT_CARD_VIEW_HEIGHT;
}