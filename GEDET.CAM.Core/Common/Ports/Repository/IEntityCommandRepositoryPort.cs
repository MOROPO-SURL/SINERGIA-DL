using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.GEDET.CAM.Core.Common.Ports.Repository;

public interface IEntityCommandRepositoryPort<TEntity, TId> where TEntity : class, IEntity<TId>
{
    Task<TEntity> AddAsync(TEntity entity, bool commit = true);

    Task<TEntity> UpdateAsync(TEntity entity, bool commit = true);

    Task DeleteAsync(TEntity entity, bool commit = true);
}
