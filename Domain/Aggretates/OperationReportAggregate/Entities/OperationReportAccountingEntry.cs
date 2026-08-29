using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OperationReportAggregate.Enumerations;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OperationReportAggregate.Entities;

public sealed class OperationReportAccountingEntry
{
    private OperationReportAccountingEntry() { }

    public OperationReportAccountingEntry(OperationReportAccountingEntryKind kind, Values.OperationReportId reportId, OperationReportAccountingEntryCurrency currency, float amount)
    {
        Kind = kind;
        ReportId = reportId;
        Currency = currency;
        Amount = amount;
    }

    public OperationReportAccountingEntryKind Kind { get; set; }

    public Values.OperationReportId ReportId { get; set; }

    public OperationReportAccountingEntryCurrency Currency { get; set; }

    public float Amount { get; set; }
}
