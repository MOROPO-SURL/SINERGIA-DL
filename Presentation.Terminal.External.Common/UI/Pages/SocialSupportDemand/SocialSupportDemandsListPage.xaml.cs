using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Clients;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.SocialSupportDemand.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Presenters.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.Common.Models.Page.SocialSupportDemand;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.Common.UI.Pages.SocialSupportDemand;

public partial class SocialSupportDemandsListPage :
    BaseListEntityPage<SocialSupportDemandBasicDtoModel, SocialSupportDemandsListPageModel>,
    IListItemsPageModelPresenter<SocialSupportDemandBasicDtoModel>
{
    public SocialSupportDemandsListPage() : base(new SocialSupportDemandsListPageModel())
    {
        InitializeComponent();

        ConcreteBindingContext.BindPresenter(this);
    }

    public async Task PresentItemDetailUserInterfaceAsync(SocialSupportDemandBasicDtoModel model)
    {
        ConcreteBindingContext.IsBusy = true;

        SocialSupportDemandQueryApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        SocialSupportDemandDetailDtoModel result = await apiClient.GetAsync(model.Id);

        Dispatcher.Dispatch(() =>
        {
            ConcreteBindingContext.IsBusy = false;

            this.NavigationPushPageAsync(new Detail.SocialSupportDemandDetailPage(result));
        });
    }

    protected override CollectionView GetItemsCollectionView() => ItemsCollectionView;

    protected override double MeasureCollectionViewCellHeight(double width) => Terminal.Common.Constants.CardViewSizeConstants.SOCIALSUPPORTDEMAND_DEFAULT_CARD_VIEW_HEIGHT;
}