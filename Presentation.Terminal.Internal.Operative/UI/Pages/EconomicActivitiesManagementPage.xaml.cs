using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.EconomicActivity.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Presenters.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.EconomicActivity;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.EconomicActivity;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages;

public partial class EconomicActivitiesManagementPage :
    BaseListEntityPage<EconomicActivityBasicDtoModel, EconomicActivitiesManagementPageModel>,
    IListItemsPageModelPresenter<EconomicActivityBasicDtoModel>,
    IManagementItemsPageModelPresenter
{
    public EconomicActivitiesManagementPage() : base(new EconomicActivitiesManagementPageModel())
    {
        InitializeComponent();

        ConcreteBindingContext.BindPresenter(this as IListItemsPageModelPresenter<EconomicActivityBasicDtoModel>);
        ConcreteBindingContext.BindPresenter(this);
    }

    public Task PresentItemCreateUserInterfaceAsync()
    {
        EconomicActivityConfigurationPageModel model = new(null, _ => ConcreteBindingContext.LoadItems(true), new Validators.EconomicActivityConfigurationValidator());

        Dispatcher.Dispatch(() => this.NavigationPushPageAsync(new EconomicActivityConfigurationPage(model)));

        return Task.CompletedTask;
    }

    public async Task PresentItemDetailUserInterfaceAsync(EconomicActivityBasicDtoModel model)
    {
        ConcreteBindingContext.IsBusy = true;

        EconomicActivityQueryApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        EconomicActivityDetailDtoModel result = await apiClient.GetAsync(model.Id);

        Dispatcher.Dispatch(() =>
        {
            ConcreteBindingContext.IsBusy = false;

            this.NavigationPushPageAsync(new EconomicActivityDetailPage(result));
        });
    }

    protected override CollectionView GetItemsCollectionView() => ItemsCollectionView;

    protected override double MeasureCollectionViewCellHeight(double width) => Constants.CardViewSizeConstants.ECONOMICACTIVITY_DEFAULT_CARD_VIEW_HEIGHT;
}