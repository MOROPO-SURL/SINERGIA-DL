namespace MOROPO.GEDET.CAM.Domain.Common.Aggregate.Contract;

public interface IEntity<TId>
{
    TId Id { get; }
}
