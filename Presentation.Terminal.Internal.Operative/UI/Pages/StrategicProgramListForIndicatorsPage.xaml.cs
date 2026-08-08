using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProgram.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Presenters.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicProgram;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.StrategicProgram;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages;

public partial class StrategicProgramListForIndicatorsPage :
    BaseListEntityPage<StrategicProgramBasicDtoModel, StrategicProgramListForIndicatorsPageModel>,
    IListItemsPageModelPresenter<StrategicProgramBasicDtoModel>
{
    public StrategicProgramListForIndicatorsPage() : base(new StrategicProgramListForIndicatorsPageModel())
    {
        InitializeComponent();

        ConcreteBindingContext.BindPresenter(this);
    }

    public async Task PresentItemDetailUserInterfaceAsync(StrategicProgramBasicDtoModel model)
    {
        ConcreteBindingContext.IsBusy = true;

        StrategicProgramQueryApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        StrategicProgramDetailDtoModel result = await apiClient.GetAsync(model.Id);

        Dispatcher.Dispatch(() =>
        {
            ConcreteBindingContext.IsBusy = false;

            this.NavigationPushPageAsync(new ActionIndicatorStateListPage(result));
        });
    }

    protected override CollectionView GetItemsCollectionView() => ItemsCollectionView;

    protected override double MeasureCollectionViewCellHeight(double width) => Constants.CardViewSizeConstants.STRATEGICPROGRAM_DEFAULT_CARD_VIEW_HEIGHT;
}