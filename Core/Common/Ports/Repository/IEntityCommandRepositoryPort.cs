using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Ports.Repository;

public interface IEntityCommandRepositoryPort<TEntity, TId, TIdValue>
    where TEntity : class, IEntity<TId, TIdValue>
    where TId : struct, IId<TIdValue>
{
    Task<TEntity> GetAsync(TId id);

    Task AddAsync(TEntity entity, bool commit = true);

    Task UpdateAsync(TEntity entity, bool commit = true);

    Task DeleteAsync(TEntity entity, bool commit = true);
}