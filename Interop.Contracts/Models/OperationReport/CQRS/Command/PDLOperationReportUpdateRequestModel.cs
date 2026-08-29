using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Document.CQRS.Command;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.OperationReport.CQRS.Command;

public record PDLOperationReportUpdateRequestModel(
    long Id,
    DateOnly Period,
    int EmployeeCount,
    int FemaleEmployeeCount,
    int DiscapacityEmployeeCount,
    float GridEnergySpend,
    float RenerenewableEnergyGeneration,
    float RenerenewableEnergyExportation,
    float Income,
    float IncomeBankDeposit,
    float PeriodResult,
    float CAMComission,
    IEnumerable<DocumentCreateRequestModel> InDocuments,
    IEnumerable<Guid> OutDocumentIds,
    string? Description = null);
