using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Feature.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.Feature;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.Feature;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Presenters.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages;

public partial class FeaturesManagementPage :
    BaseListEntityPage<FeatureBasicDtoModel, FeaturesManagementPageModel>,
    IListItemsPageModelPresenter<FeatureBasicDtoModel>,
    IManagementItemsPageModelPresenter
{
    public FeaturesManagementPage() : base(new FeaturesManagementPageModel())
    {
        InitializeComponent();

        ConcreteBindingContext.BindPresenter(this as IListItemsPageModelPresenter<FeatureBasicDtoModel>);
        ConcreteBindingContext.BindPresenter(this);
    }

    public async Task PresentItemCreateUserInterfaceAsync()
    {
        FeatureKindQueryApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        FeatureConfigurationPageModel model = new(null, _ => ConcreteBindingContext.LoadItems(true))
        {
            AvailableKinds = [.. (await apiClient.GetPageAsync(1, 30)).Items]
        };

        Dispatcher.Dispatch(() => this.NavigationPushPageAsync(new FeatureConfigurationPage(model)));
    }

    public async Task PresentItemDetailUserInterfaceAsync(FeatureBasicDtoModel model)
    {
        ConcreteBindingContext.IsBusy = true;

        FeatureQueryApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        FeatureDetailDtoModel result = await apiClient.GetAsync(model.Id);

        Dispatcher.Dispatch(() =>
        {
            ConcreteBindingContext.IsBusy = false;

            this.NavigationPushPageAsync(new FeatureDetailPage(result));
        });
    }

    protected override CollectionView GetItemsCollectionView() => ItemsCollectionView;

    protected override double MeasureCollectionViewCellHeight(double width) => Constants.CardViewSizeConstants.FEATURE_DEFAULT_CARD_VIEW_HEIGHT;
}