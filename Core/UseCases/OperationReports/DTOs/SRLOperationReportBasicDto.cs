using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Organizations.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.OperationReports.DTOs;

public record SRLOperationReportBasicDto(long Id, DateTime At, DateOnly Period, OrganizationBasicDto Organization) : IDto;