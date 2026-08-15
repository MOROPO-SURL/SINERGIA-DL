using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Organization.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.OperationReport.DTOs;

public record SRLOperationReportBasicDtoModel(long Id, DateTime At, DateOnly Period, OrganizationBasicDtoModel Organization);