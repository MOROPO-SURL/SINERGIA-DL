using Microsoft.EntityFrameworkCore;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.OperationReports.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OperationReportAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OperationReportAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.OperationReports;

internal sealed class SRLOperationReportCommandRepositoryPortAdapter : AbstractEntityCommandRepositoryPortAdapter<SRLOperationReport, OperationReportId, long>, ISRLOperationReportCommandRepositoryPort
{
    public SRLOperationReportCommandRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }

    protected override IQueryable<SRLOperationReport> GetQueryableDbSet()
    {
        return base.GetQueryableDbSet()
            .AsSplitQuery()
            .Include(entity => entity.DocumentBridges).ThenInclude(bridge => bridge.Linked);
    }
}
