using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Organization.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.OperationReport.DTOs;

public record SRLOperationReportBasicDtoModel(long Id, DateTime At, DateOnly Period, OrganizationBasicDtoModel Organization);