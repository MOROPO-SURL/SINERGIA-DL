using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.OperationReport.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Presenters.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.PDL.Models.Page.OperationReport;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.Common.Models.Page;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.PDL.UI.Pages.OperationReport;

public partial class OperationReportDetailPage : BaseDetailEntityPage<PDLOperationReportDetailDtoModel, OperationReportDetailPageModel>, IDetailItemPageModelPresenter<PDLOperationReportDetailDtoModel>
{
    public OperationReportDetailPage(PDLOperationReportDetailDtoModel model) : base(new OperationReportDetailPageModel(model))
    {
        InitializeComponent();

        ConcreteBindingContext.BindPresenter(this);
    }

    public Task PresentItemModifyUserInterfaceAsync(PDLOperationReportDetailDtoModel model, Action<PDLOperationReportDetailDtoModel> configurationSuccessCallbackAction)
    {
        return this.NavigationPushPageAsync(new OperationReportConfigurationPage(new OperationReportConfigurationPageModel(((AppShellPageModel)((Shells.AppShell)Application.Current!.MainPage!).BindingContext).DevelopmentProfileId!.Value, model, configurationSuccessCallbackAction, new Validators.OperationReportConfigurationValidator())));
    }
}