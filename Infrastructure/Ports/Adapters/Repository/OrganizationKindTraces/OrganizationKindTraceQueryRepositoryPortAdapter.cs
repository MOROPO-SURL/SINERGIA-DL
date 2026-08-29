using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.OrganizationKindTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.OrganizationKindTraces;

internal sealed class OrganizationKindTraceQueryRepositoryPortAdapter : AbstractEntityQueryRepositoryPortAdapter<OrganizationKindTrace, TraceId, long>, IOrganizationKindTraceQueryRepositoryPort
{
    public OrganizationKindTraceQueryRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }
}
