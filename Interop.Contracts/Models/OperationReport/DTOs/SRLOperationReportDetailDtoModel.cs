using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Enumerations;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Document.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Organization.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.OperationReport.DTOs;

public record SRLOperationReportDetailDtoModel(
    long Id,
    DateTime At,
    DateOnly Period,
    OrganizationBasicDtoModel Organization,
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
    IEnumerable<DocumentBasicDtoModel> Documents,
    string? Description = null);