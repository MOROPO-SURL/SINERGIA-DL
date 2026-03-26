namespace MOROPO.GEDET.CAM.Domain.Common.Aggregate.Contract;

public interface IPriorizableEntity<TId> : IEntity<TId>
{
    int Priority { get; set; }
}
