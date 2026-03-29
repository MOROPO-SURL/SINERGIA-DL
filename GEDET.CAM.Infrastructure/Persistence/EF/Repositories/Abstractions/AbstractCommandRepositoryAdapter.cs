using Microsoft.EntityFrameworkCore;
using MOROPO.GEDET.CAM.Core.Common.Ports.Repository;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.GEDET.CAM.Infrastructure.Persistence.EF.Repositories.Abstractions;

public abstract class AbstractCommandRepositoryAdapter<TEntity, TId> : IEntityCommandRepositoryPort<TEntity, TId> where TEntity : class, IEntity<TId> where TId : struct
{
    protected readonly DefaultDbContext dbContext;

    protected AbstractCommandRepositoryAdapter(DefaultDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    private DbSet<TEntity> DbSet => dbContext.Set<TEntity>();

    public async Task<TEntity> AddAsync(TEntity entity, bool commit = true)
    {
        await DbSet.AddAsync(entity);

        if (commit) await dbContext.SaveChangesAsync(commit);

        return entity;
    }

    public async Task DeleteAsync(TEntity entity, bool commit = true)
    {
        DbSet.Remove(entity);

        if (commit) await dbContext.SaveChangesAsync(commit);
    }

    public async Task<TEntity> UpdateAsync(TEntity entity, bool commit = true)
    {
        var entry = dbContext.Entry(entity);

        DbSet.Update(entity);

        entry.State = EntityState.Modified;

        if (commit) await dbContext.SaveChangesAsync(commit);

        return entity;
    }
}
