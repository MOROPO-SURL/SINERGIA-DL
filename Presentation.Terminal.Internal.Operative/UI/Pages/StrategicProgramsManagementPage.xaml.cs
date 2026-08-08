using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicLine.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProgram.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicProgram;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicProgram.Configuration;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.StrategicProgram.Configuration;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.StrategicProgram.Detail;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Presenters.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages;

public partial class StrategicProgramsManagementPage : 
    BaseListEntityPage<StrategicProgramBasicDtoModel, StrategicProgramsManagementPageModel>, 
    IListItemsPageModelPresenter<StrategicProgramBasicDtoModel>,
    IManagementItemsPageModelPresenter
{
	public StrategicProgramsManagementPage() : base(new StrategicProgramsManagementPageModel())
	{
		InitializeComponent();

        ConcreteBindingContext.BindPresenter(this as IListItemsPageModelPresenter<StrategicProgramBasicDtoModel>);
        ConcreteBindingContext.BindPresenter(this);
    }

    public async Task PresentItemCreateUserInterfaceAsync()
    {
        StrategicLineQueryApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        StrategicLineBasicDtoModel[] lines = (await apiClient.GetPageAsync(1, 100)).Items;

        Dispatcher.Dispatch(() => this.NavigationPushPageAsync(new StrategicProgramConfigurationPage(new StrategicProgramConfigurationPageModel(null, lines, model => ConcreteBindingContext.LoadItems(true)))));
    }

    public async Task PresentItemDetailUserInterfaceAsync(StrategicProgramBasicDtoModel model)
    {
        ConcreteBindingContext.IsBusy = true;

        StrategicProgramQueryApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        StrategicProgramDetailDtoModel result = await apiClient.GetAsync(model.Id);

        Dispatcher.Dispatch(() =>
        {
            ConcreteBindingContext.IsBusy = false;

            this.NavigationPushPageAsync(new StrategicProgramDetailPage(result));
        });
    }

    protected override CollectionView GetItemsCollectionView() => ItemsCollectionView;

    protected override double MeasureCollectionViewCellHeight(double width) => Constants.CardViewSizeConstants.STRATEGICPROGRAM_DEFAULT_CARD_VIEW_HEIGHT;
}