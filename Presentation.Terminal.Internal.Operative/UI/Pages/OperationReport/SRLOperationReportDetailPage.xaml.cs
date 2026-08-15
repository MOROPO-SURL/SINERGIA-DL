using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.OperationReport.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.OperationReport;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.OperationReport;

public partial class SRLOperationReportDetailPage : BaseDetailEntityPage<SRLOperationReportDetailDtoModel, SRLOperationReportDetailPageModel>
{
    public SRLOperationReportDetailPage(SRLOperationReportDetailDtoModel model) : base(new SRLOperationReportDetailPageModel(model))
    {
        InitializeComponent();
    }
}