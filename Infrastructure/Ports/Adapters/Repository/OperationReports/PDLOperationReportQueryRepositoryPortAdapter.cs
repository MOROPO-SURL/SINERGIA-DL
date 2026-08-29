using Microsoft.EntityFrameworkCore;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.OperationReports.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OperationReportAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OperationReportAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.OperationReports;

internal sealed class PDLOperationReportQueryRepositoryPortAdapter : AbstractEntityQueryRepositoryPortAdapter<PDLOperationReport, OperationReportId, long>, IPDLOperationReportQueryRepositoryPort
{
    public PDLOperationReportQueryRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }

    protected override IQueryable<PDLOperationReport> GetQueryableDbSet()
    {
        return base.GetQueryableDbSet()
            .Include(entity => entity.Owner).ThenInclude(entity => entity!.Owner).ThenInclude(entity => entity!.Image)
            .Include(entity => entity.DocumentBridges).ThenInclude(bridge => bridge.Linked);
    }
}