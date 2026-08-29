using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Clients;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.SocialResponsabilityAction.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Presenters.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.SocialResponsabilityAction;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.SocialResponsabilityAction;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages;

public partial class PDLSocialResponsabilityActionsListPage :
    BaseListEntityPage<PDLSocialResponsabilityActionBasicDtoModel, PDLSocialResponsabilityActionsListPageModel>,
    IListItemsPageModelPresenter<PDLSocialResponsabilityActionBasicDtoModel>
{
    public PDLSocialResponsabilityActionsListPage() : base(new PDLSocialResponsabilityActionsListPageModel())
    {
        InitializeComponent();

        ConcreteBindingContext.BindPresenter(this);
    }

    public async Task PresentItemDetailUserInterfaceAsync(PDLSocialResponsabilityActionBasicDtoModel model)
    {
        ConcreteBindingContext.IsBusy = true;

        PDLSocialResponsabilityActionQueryApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        PDLSocialResponsabilityActionDetailDtoModel result = await apiClient.GetAsync(model.Id);

        Dispatcher.Dispatch(() =>
        {
            ConcreteBindingContext.IsBusy = false;

            this.NavigationPushPageAsync(new PDLSocialResponsabilityActionDetailPage(result));
        });
    }

    protected override CollectionView GetItemsCollectionView() => ItemsCollectionView;

    protected override double MeasureCollectionViewCellHeight(double width) => Constants.CardViewSizeConstants.SOCIALRESPONSABILITYACTION_DEFAULT_CARD_VIEW_HEIGHT;
}