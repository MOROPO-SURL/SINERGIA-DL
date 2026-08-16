using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DocumentAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DocumentAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OperationReportAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OperationReportAggregate.Bridges;

public sealed class OperationReportDocumentBridge
{
    private OperationReportDocumentBridge() { }

    public OperationReportDocumentBridge(OperationReportId mainId, DocumentId linkedId, Document? linked = null)
    {
        MainId = mainId;
        LinkedId = linkedId;
        Linked = linked;
    }

    public OperationReportId MainId { get; set; }

    public DocumentId LinkedId { get; set; }

    public Document? Linked { get; set; }
}