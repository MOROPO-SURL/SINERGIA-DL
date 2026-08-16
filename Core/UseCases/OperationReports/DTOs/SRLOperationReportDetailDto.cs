using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Documents.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Organizations.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OperationReportAggregate.Enumerations;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OperationReports.DTOs;

public record SRLOperationReportDetailDto(
    long Id, 
    DateTime At,
    DateOnly Period,
    OrganizationBasicDto Organization,
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
    IEnumerable<DocumentBasicDto> Documents,
    string? Description = null) : IDetailDto;