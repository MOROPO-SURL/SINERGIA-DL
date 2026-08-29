using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Documents.CQRS.Command;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.OperationReports.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.OperationReports.CQRS.Command.Update;

public record PDLOperationReportUpdateCommand(
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
    IEnumerable<DocumentCreateCommand> InDocuments,
    IEnumerable<Guid> OutDocumentIds,
    string? Description = null) : IUpdateCommand<long, PDLOperationReportDetailDto>;