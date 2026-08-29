using Microsoft.EntityFrameworkCore;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Repositories.Abstractions;

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

    protected virtual IQueryable<TEntity> GetQueryableDbSet() => dbContext.Set<TEntity>();

    public Task<TEntity> GetAsync(TId id)
    {
        return GetQueryableDbSet().Where(entity => entity.Id.Equals(id)).FirstAsync();
    }

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