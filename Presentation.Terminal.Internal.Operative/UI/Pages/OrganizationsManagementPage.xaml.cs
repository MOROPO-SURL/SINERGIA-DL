using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Organization.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.OrganizationKind.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.UI.Presenters.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Models.Page.Organization;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.UI.Pages.Organization;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.UI.Pages;

public partial class OrganizationsManagementPage :
    BaseManagementEntityPage<OrganizationBasicDtoModel, OrganizationDetailDtoModel, OrganizationsManagementPageModel, OrganizationConfigurationPageModel>,
    IListItemsPageModelPresenter<OrganizationBasicDtoModel>,
    IManagementItemsPageModelPresenter
{
    public OrganizationsManagementPage()
    {
        InitializeComponent();

        ConcreteBindingContext.BindPresenter(this as IListItemsPageModelPresenter<OrganizationBasicDtoModel>);
        ConcreteBindingContext.BindPresenter(this);
    }

    public async Task PresentItemCreateUserInterfaceAsync()
    {
        OrganizationKindQueryApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        OrganizationKindBasicDtoModel[] kinds = (await apiClient.GetPageAsync(1, 30)).Items;

        Dispatcher.Dispatch(() => this.NavigationPushPageAsync(new OrganizationConfigurationPage(new OrganizationConfigurationPageModel(null, kinds, model => ConcreteBindingContext.LoadItems(true)))));
    }

    public async Task PresentItemDetailUserInterfaceAsync(OrganizationBasicDtoModel model)
    {
        ConcreteBindingContext.IsBusy = true;

        OrganizationQueryApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        OrganizationDetailDtoModel result = await apiClient.GetAsync(model.Id);

        Dispatcher.Dispatch(() =>
        {
            ConcreteBindingContext.IsBusy = false;

            this.NavigationPushPageAsync(new OrganizationDetailPage(result));
        });
    }

    protected override CollectionView GetItemsCollectionView() => ItemsCollectionView;

    protected override double MeasureCollectionViewCellHeight(double width) => Constants.CardViewSizeConstants.ORGANIZATION_DEFAULT_CARD_VIEW_HEIGHT;
}