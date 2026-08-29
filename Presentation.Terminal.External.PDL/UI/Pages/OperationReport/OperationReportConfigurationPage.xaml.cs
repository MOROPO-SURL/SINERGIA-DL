using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.OperationReport.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Presenters;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.PDL.Models.Page.OperationReport;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.PDL.UI.Pages.OperationReport;

public partial class OperationReportConfigurationPage : BaseConfigurationEntityPage<PDLOperationReportDetailDtoModel, PDLOperationReportDetailDtoModel, OperationReportConfigurationPageModel>
{
    public OperationReportConfigurationPage(OperationReportConfigurationPageModel bindingContextModel) : base(bindingContextModel)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Informe al CAM";

    private void AddDocumentButton_Clicked(object sender, EventArgs eventArgs)
    {
        DocumentPickPresenter.Instance.BeginDocumentPickAsync(this, ConcreteBindingContext.DocumentPickSuccess_Callback);
    }
}