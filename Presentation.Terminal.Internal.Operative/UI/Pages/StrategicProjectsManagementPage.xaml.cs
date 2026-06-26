using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProgram.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProject.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProjectKind.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicProject;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicProject.Configuration;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.StrategicProject.Configuration;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.StrategicProject.Detail;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Presenters.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages;

public partial class StrategicProjectsManagementPage : 
    BaseListEntityPage<StrategicProjectBasicDtoModel, StrategicProjectsManagementPageModel>, 
    IListItemsPageModelPresenter<StrategicProjectBasicDtoModel>,
    IManagementItemsPageModelPresenter
{
	public StrategicProjectsManagementPage() : base(new StrategicProjectsManagementPageModel())
	{
		InitializeComponent();

        ConcreteBindingContext.BindPresenter(this as IListItemsPageModelPresenter<StrategicProjectBasicDtoModel>);
        ConcreteBindingContext.BindPresenter(this);
    }

    public async Task PresentItemCreateUserInterfaceAsync()
    {
        IHttpClientProviderPort httpClientProvider = IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>();

        StrategicProjectKindQueryApiClient projectKindApiClient = new(httpClientProvider);
        StrategicProgramQueryApiClient programApiClient = new(httpClientProvider);

        StrategicProjectKindBasicDtoModel[] kinds = (await projectKindApiClient.GetPageAsync(1, 30)).Items;
        StrategicProgramBasicDtoModel[] programs = (await programApiClient.GetPageAsync(1, 30)).Items;

        Dispatcher.Dispatch(() => this.NavigationPushPageAsync(new StrategicProjectConfigurationPage(new StrategicProjectConfigurationPageModel(null, kinds, programs, model => ConcreteBindingContext.LoadItems(true)))));
    }

    public async Task PresentItemDetailUserInterfaceAsync(StrategicProjectBasicDtoModel model)
    {
        ConcreteBindingContext.IsBusy = true;

        StrategicProjectQueryApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        StrategicProjectDetailDtoModel result = await apiClient.GetAsync(model.Id);

        Dispatcher.Dispatch(() =>
        {
            ConcreteBindingContext.IsBusy = false;

            this.NavigationPushPageAsync(new StrategicProjectDetailPage(result));
        });
    }

    protected override CollectionView GetItemsCollectionView() => ItemsCollectionView;

    protected override double MeasureCollectionViewCellHeight(double width) => Constants.CardViewSizeConstants.STRATEGICPROJECT_DEFAULT_CARD_VIEW_HEIGHT;
}