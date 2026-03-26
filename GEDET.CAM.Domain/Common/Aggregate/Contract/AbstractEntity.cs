namespace MOROPO.GEDET.CAM.Domain.Common.Aggregate.Contract;

public abstract class AbstractEntity<TId> : IEntity<TId>
{
    protected AbstractEntity(TId id)
    {
        Id = id;
    }

    public TId Id { get; private set; }

}
