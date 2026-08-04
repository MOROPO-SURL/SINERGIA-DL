using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OperationReports.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OperationReportAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OperationReportAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.OperationReports;

internal sealed class PDLOperationReportCommandRepositoryPortAdapter : AbstractEntityCommandRepositoryPortAdapter<PDLOperationReport, OperationReportId, long>, IPDLOperationReportCommandRepositoryPort
{
    public PDLOperationReportCommandRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }
}