namespace MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;

public interface IAggregateRoot<TId, TIdValue> : IEntity<TId, TIdValue> where TId : struct, IId<TIdValue>
{
}