using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Contract;

namespace MOROPO.GEDET.CAM.Domain.Common.Ports.Repository;

public interface IEntityCommandRepositoryPort<TEntity, TId> where TEntity : class, IEntity<TId>
{
    TEntity Add(TEntity entity, string author, bool commit = true);

    TEntity Update(TEntity entity, string author, bool commit = true);

    void Delete(TEntity entity, string author, bool commit = true);
}
