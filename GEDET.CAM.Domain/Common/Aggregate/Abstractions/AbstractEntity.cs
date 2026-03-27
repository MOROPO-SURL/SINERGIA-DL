using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.GEDET.CAM.Domain.Common.Aggregate.Abstractions;

public abstract class AbstractEntity<TId> : IEntity<TId>
{
    protected AbstractEntity(TId id)
    {
        Id = id;
    }

    public TId Id { get; set; }
}
