using Microsoft.EntityFrameworkCore;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Organizations.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OrganizationAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OrganizationAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.Organizations;

internal sealed class OrganizationCommandRepositoryPortAdapter :
    AbstractEntityCommandRepositoryPortAdapter<Organization, OrganizationId, Guid>,
    IOrganizationCommandRepositoryPort
{
    public OrganizationCommandRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }

    protected override IQueryable<Organization> GetQueryableDbSet()
    {
        return base.GetQueryableDbSet()
            .AsSplitQuery()
            .Include(entity => entity.Image)
            .Include(entity => entity.PersonBridges);
    }
}
