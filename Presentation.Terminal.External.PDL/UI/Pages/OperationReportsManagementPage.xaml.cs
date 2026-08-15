using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.OperationReport.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Presenters.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.PDL.Models.Page.OperationReport;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.PDL.UI.Pages.OperationReport;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.PDL.UI.Pages;

public partial class OperationReportsManagementPage :
    BaseListEntityPage<PDLOperationReportBasicDtoModel, OperationReportsManagementPageModel>,
    IListItemsPageModelPresenter<PDLOperationReportBasicDtoModel>,
    IManagementItemsPageModelPresenter
{
    public OperationReportsManagementPage() : base(new OperationReportsManagementPageModel())
    {
        InitializeComponent();

        ConcreteBindingContext.BindPresenter(this as IListItemsPageModelPresenter<PDLOperationReportBasicDtoModel>);
        ConcreteBindingContext.BindPresenter(this);
    }

    public Task PresentItemCreateUserInterfaceAsync()
    {
        Dispatcher.Dispatch(() => this.NavigationPushPageAsync(new OperationReportConfigurationPage(new OperationReportConfigurationPageModel(((Common.Models.Page.AppShellPageModel)((Shells.AppShell)Application.Current!.MainPage!).BindingContext).DevelopmentProfileId!.Value, null, _ => ConcreteBindingContext.LoadItems(true), new Validators.OperationReportConfigurationValidator()))));

        return Task.CompletedTask;
    }

    public async Task PresentItemDetailUserInterfaceAsync(PDLOperationReportBasicDtoModel model)
    {
        ConcreteBindingContext.IsBusy = true;

        PDLOperationReportQueryApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        PDLOperationReportDetailDtoModel result = await apiClient.GetAsync(model.Id);

        Dispatcher.Dispatch(() =>
        {
            ConcreteBindingContext.IsBusy = false;

            this.NavigationPushPageAsync(new OperationReportDetailPage(result));
        });
    }

    protected override CollectionView GetItemsCollectionView() => ItemsCollectionView;

    protected override double MeasureCollectionViewCellHeight(double width) => Common.Constants.CardViewSizeConstants.OPERATIONREPORT_DEFAULT_CARD_VIEW_HEIGHT;
}