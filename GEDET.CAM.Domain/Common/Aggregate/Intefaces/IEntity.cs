namespace MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;

public interface IEntity<TId>
{
    TId Id { get; }
}
