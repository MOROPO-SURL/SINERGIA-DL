using Microsoft.EntityFrameworkCore;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Repositories.Abstractions;

public abstract class AbstractEntityCommandRepositoryPortAdapter<TEntity, TId, TIdValue> : IEntityCommandRepositoryPort<TEntity, TId, TIdValue>
    where TEntity : class, IEntity<TId, TIdValue>
    where TId : struct, IId<TIdValue>
{
    protected readonly DefaultDbContext dbContext;

    protected AbstractEntityCommandRepositoryPortAdapter(DefaultDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    private DbSet<TEntity> DbSet => dbContext.Set<TEntity>();

    public async Task AddAsync(TEntity entity, bool commit = true)
    {
        await DbSet.AddAsync(entity);

        if (commit) await dbContext.SaveChangesAsync(commit);
    }

    public async Task DeleteAsync(TEntity entity, bool commit = true)
    {
        DbSet.Remove(entity);

        if (commit) await dbContext.SaveChangesAsync(commit);
    }

    public async Task UpdateAsync(TEntity entity, bool commit = true)
    {
        DbSet.Update(entity);

        if (commit) await dbContext.SaveChangesAsync(commit);
    }
}