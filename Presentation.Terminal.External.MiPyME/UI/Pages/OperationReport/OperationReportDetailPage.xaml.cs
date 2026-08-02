using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.OperationReport.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Presenters.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.MiPyME.Models.Page.OperationReport;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.Common.Models.Page;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.MiPyME.UI.Pages.OperationReport;

public partial class OperationReportDetailPage : BaseDetailEntityPage<SRLOperationReportDetailDtoModel, OperationReportDetailPageModel>, IDetailItemPageModelPresenter<SRLOperationReportDetailDtoModel>
{
    public OperationReportDetailPage(SRLOperationReportDetailDtoModel model) : base(new OperationReportDetailPageModel(model))
    {
        InitializeComponent();

        ConcreteBindingContext.BindPresenter(this);
    }

    public Task PresentItemModifyUserInterfaceAsync(SRLOperationReportDetailDtoModel model, Action<SRLOperationReportDetailDtoModel> configurationSuccessCallbackAction)
    {
        return this.NavigationPushPageAsync(new OperationReportConfigurationPage(new OperationReportConfigurationPageModel(((AppShellPageModel)((Shells.AppShell)Application.Current!.MainPage!).BindingContext).DevelopmentProfileId!.Value, model, configurationSuccessCallbackAction, new Validators.OperationReportConfigurationValidator())));
    }
}