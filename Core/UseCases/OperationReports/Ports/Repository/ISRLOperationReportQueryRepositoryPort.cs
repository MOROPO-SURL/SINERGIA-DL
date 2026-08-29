using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OperationReportAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OperationReportAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.OperationReports.Ports.Repository;

public interface ISRLOperationReportQueryRepositoryPort : IEntityQueryRepositoryPort<SRLOperationReport, OperationReportId, long>
{
}
