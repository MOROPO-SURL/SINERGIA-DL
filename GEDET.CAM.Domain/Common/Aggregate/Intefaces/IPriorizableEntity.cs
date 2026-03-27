namespace MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;

public interface IPriorizableEntity<TId> : IEntity<TId>
{
    int Priority { get; set; }
}
