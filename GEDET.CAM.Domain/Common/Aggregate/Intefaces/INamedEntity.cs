namespace MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;

public interface INamedEntity<TId> : IEntity<TId>
{
    string Name { get; set; }
}
