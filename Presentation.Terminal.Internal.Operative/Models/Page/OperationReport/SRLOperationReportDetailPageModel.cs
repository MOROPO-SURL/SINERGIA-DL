using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.OperationReport.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.OperationReport;

public sealed class SRLOperationReportDetailPageModel : AbstractDetailEntityPageModel<SRLOperationReportDetailDtoModel>
{
    public SRLOperationReportDetailPageModel(SRLOperationReportDetailDtoModel model) : base(model)
    {
    }

    protected override Task PerformRemotionAsync(SRLOperationReportDetailDtoModel model)
    {
        throw new NotImplementedException();
    }
}
