using Microsoft.EntityFrameworkCore;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Repositories.Abstractions;

internal class AbstractBridgeCommandRepositoryPortAdapter<TBridge, TMainEntity, TMainEntityId, TMainEntityIdValue, TLinkedEntity, TLinkedEntityId, TLinkedEntityIdValue> : IBridgeCommandRepositoryPort<TBridge, TMainEntity, TMainEntityId, TMainEntityIdValue, TLinkedEntity, TLinkedEntityId, TLinkedEntityIdValue>
    where TBridge : class, IBridge<TMainEntity, TMainEntityId, TMainEntityIdValue, TLinkedEntity, TLinkedEntityId, TLinkedEntityIdValue>
    where TMainEntity : AbstractEntity<TMainEntityId, TMainEntityIdValue>
    where TMainEntityId : struct, IId<TMainEntityIdValue>
    where TLinkedEntity : AbstractEntity<TLinkedEntityId, TLinkedEntityIdValue>
    where TLinkedEntityId : struct, IId<TLinkedEntityIdValue>
{
    protected readonly DefaultDbContext dbContext;

    protected AbstractBridgeCommandRepositoryPortAdapter(DefaultDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    private DbSet<TBridge> DbSet => dbContext.Set<TBridge>();

    public async Task<TBridge> AddAsync(TBridge entity, bool commit = true)
    {
        await DbSet.AddAsync(entity);

        if (commit) await dbContext.SaveChangesAsync(commit);

        return entity;
    }

    public async Task DeleteAsync(TBridge entity, bool commit = true)
    {
        DbSet.Remove(entity);
        if (commit) await dbContext.SaveChangesAsync(commit);
    }

    public async Task<TBridge> UpdateAsync(TBridge entity, bool commit = true)
    {
        DbSet.Update(entity);

        if (commit) await dbContext.SaveChangesAsync(commit);

        return entity;
    }
}