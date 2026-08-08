using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.OperationReport.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.OperationReport;

public sealed class PDLOperationReportDetailPageModel : AbstractDetailEntityPageModel<PDLOperationReportDetailDtoModel>
{
    public PDLOperationReportDetailPageModel(PDLOperationReportDetailDtoModel model) : base(model)
    {
    }

    protected override Task PerformRemotionAsync(PDLOperationReportDetailDtoModel model)
    {
        throw new NotImplementedException();
    }
}