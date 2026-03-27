namespace MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;

public interface IEnableableEntity<TId> : IEntity<TId>
{
    bool Enabled { get; set; }
}
