using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.OperationReport.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.MiPyME.Models.Page.OperationReport;

public sealed class OperationReportDetailPageModel : AbstractDetailEntityPageModel<SRLOperationReportDetailDtoModel>
{
    public OperationReportDetailPageModel(SRLOperationReportDetailDtoModel model, Action? changeCallbackAction = null) : base(model, changeCallbackAction)
    {
    }

    protected override Task PerformRemotionAsync(SRLOperationReportDetailDtoModel model)
    {
        throw new NotImplementedException();
    }
}
