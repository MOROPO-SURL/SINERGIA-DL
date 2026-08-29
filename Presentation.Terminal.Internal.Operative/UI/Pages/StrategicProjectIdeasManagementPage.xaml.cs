using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Clients;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProgram.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProjectIdea.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicProjectIdea;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicProjectIdea.Configuration;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.StrategicProjectIdea.Configuration;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.StrategicProjectIdea.Detail;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Presenters.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages;

public partial class StrategicProjectIdeasManagementPage : 
    BaseListEntityPage<StrategicProjectIdeaBasicDtoModel, StrategicProjectIdeasManagementPageModel>, 
    IListItemsPageModelPresenter<StrategicProjectIdeaBasicDtoModel>,
    IManagementItemsPageModelPresenter
{
	public StrategicProjectIdeasManagementPage() : base(new StrategicProjectIdeasManagementPageModel())
	{
		InitializeComponent();

        ConcreteBindingContext.BindPresenter(this as IListItemsPageModelPresenter<StrategicProjectIdeaBasicDtoModel>);
        ConcreteBindingContext.BindPresenter(this);
    }

    public async Task PresentItemCreateUserInterfaceAsync()
    {
        IHttpClientProviderPort httpClientProvider = IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>();

        StrategicProgramQueryApiClient programApiClient = new(httpClientProvider);

        StrategicProgramBasicDtoModel[] programs = (await programApiClient.GetPageAsync(1, 100)).Items;

        Dispatcher.Dispatch(() => this.NavigationPushPageAsync(new StrategicProjectIdeaConfigurationPage(new StrategicProjectIdeaConfigurationPageModel(null, programs, model => ConcreteBindingContext.LoadItems(true)))));
    }

    public async Task PresentItemDetailUserInterfaceAsync(StrategicProjectIdeaBasicDtoModel model)
    {
        ConcreteBindingContext.IsBusy = true;

        StrategicProjectIdeaQueryApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        StrategicProjectIdeaDetailDtoModel result = await apiClient.GetAsync(model.Id);

        Dispatcher.Dispatch(() =>
        {
            ConcreteBindingContext.IsBusy = false;

            this.NavigationPushPageAsync(new StrategicProjectIdeaDetailPage(result));
        });
    }

    protected override CollectionView GetItemsCollectionView() => ItemsCollectionView;

    protected override double MeasureCollectionViewCellHeight(double width) => Constants.CardViewSizeConstants.STRATEGICPROJECTIDEA_DEFAULT_CARD_VIEW_HEIGHT;
}