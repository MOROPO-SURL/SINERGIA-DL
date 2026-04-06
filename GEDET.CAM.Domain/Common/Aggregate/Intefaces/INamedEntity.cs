namespace MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;

public interface INamedEntity<TId, TIdValue> : IEntity<TId, TIdValue> where TId : struct, IId<TIdValue>
{
    string Name { get; set; }
}