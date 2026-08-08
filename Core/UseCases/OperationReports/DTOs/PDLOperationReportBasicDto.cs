using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Organizations.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OperationReports.DTOs;

public record PDLOperationReportBasicDto(long Id, DateTime At, DateOnly Period, OrganizationBasicDto Organization) : IDto;