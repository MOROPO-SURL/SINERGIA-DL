using Microsoft.EntityFrameworkCore;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OperationReports.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OperationReportAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OperationReportAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.OperationReports;

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