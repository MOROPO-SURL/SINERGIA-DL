namespace MOROPO.GEDET.CAM.Domain.Common.Aggregate.Contract;

public interface INamedEntity<TId> : IEntity<TId>
{
    string Name { get; set; }
}
