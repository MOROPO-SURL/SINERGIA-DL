using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Documents.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Organizations.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.OperationReports.DTOs;

public record PDLOperationReportDetailDto(
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
    float Income,
    float IncomeBankDeposit,
    float PeriodResult,
    float CAMComission,
    IEnumerable<DocumentBasicDto> Documents,
    string? Description = null) : IDetailDto;