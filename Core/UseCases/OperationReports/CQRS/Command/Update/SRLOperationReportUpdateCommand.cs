using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Documents.CQRS.Command;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OperationReports.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OperationReportAggregate.Enumerations;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OperationReports.CQRS.Command.Update;

public record SRLOperationReportUpdateCommand(
    long Id,
    DateOnly Period,
    int EmployeeCount,
    int FemaleEmployeeCount,
    int DiscapacityEmployeeCount,
    float GridEnergySpend,
    float RenerenewableEnergyGeneration,
    float RenerenewableEnergyExportation,
    IEnumerable<KeyValuePair<OperationReportAccountingEntryCurrency, float>> IncomeSummaryEntries,
    IEnumerable<KeyValuePair<OperationReportAccountingEntryCurrency, float>> IncomeEcommerceEntries,
    IEnumerable<KeyValuePair<OperationReportAccountingEntryCurrency, float>> IncomeBankDepositEntries,
    IEnumerable<KeyValuePair<OperationReportAccountingEntryCurrency, float>> SpendSummaryEntries,
    IEnumerable<KeyValuePair<OperationReportAccountingEntryCurrency, float>> SpendPrivateSectorEntries,
    IEnumerable<KeyValuePair<OperationReportAccountingEntryCurrency, float>> SpendPublicSectorEntries,
    IEnumerable<KeyValuePair<OperationReportAccountingEntryCurrency, float>> PeriodResultEntries,
    IEnumerable<KeyValuePair<OperationReportAccountingEntryCurrency, float>> OperativeTaxEntries,
    IEnumerable<KeyValuePair<OperationReportAccountingEntryCurrency, float>> SellTaxEntries,
    IEnumerable<KeyValuePair<OperationReportAccountingEntryCurrency, float>> HumanResourcePayloadEntries,
    IEnumerable<DocumentCreateCommand> InDocuments,
    IEnumerable<Guid> OutDocumentIds,
    string? Description = null) : IUpdateCommand<long, SRLOperationReportDetailDto>;