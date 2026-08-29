using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.OrganizationTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.OrganizationTraces;

internal sealed class OrganizationTraceQueryRepositoryPortAdapter : AbstractEntityQueryRepositoryPortAdapter<OrganizationTrace, TraceId, long>, IOrganizationTraceQueryRepositoryPort
{
    public OrganizationTraceQueryRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }
}