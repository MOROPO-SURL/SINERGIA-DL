using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.OperationReport.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.PDL.Models.Page.OperationReport;

public sealed class OperationReportDetailPageModel : AbstractDetailEntityPageModel<PDLOperationReportDetailDtoModel>
{
    public OperationReportDetailPageModel(PDLOperationReportDetailDtoModel model, Action? changeCallbackAction = null) : base(model, changeCallbackAction)
    {
    }

    protected override Task PerformRemotionAsync(PDLOperationReportDetailDtoModel model)
    {
        throw new NotImplementedException();
    }
}