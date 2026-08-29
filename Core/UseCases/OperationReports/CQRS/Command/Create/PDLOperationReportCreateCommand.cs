using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Documents.CQRS.Command;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.OperationReports.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.OperationReports.CQRS.Command.Create;

public record PDLOperationReportCreateCommand(
    Guid OwnerId,
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
    IEnumerable<DocumentCreateCommand> Documents,
    string? Description = null) : ICreateCommand<PDLOperationReportDetailDto>;