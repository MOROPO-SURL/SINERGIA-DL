using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.DocumentAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.DocumentAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OperationReportAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OperationReportAggregate.Bridges;

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