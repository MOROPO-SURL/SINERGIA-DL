namespace MOROPO.GEDET.CAM.Domain.Common.Aggregate.Contract;

public interface IEnableableEntity<TId> : IEntity<TId>
{
    bool Enabled { get; set; }
}
