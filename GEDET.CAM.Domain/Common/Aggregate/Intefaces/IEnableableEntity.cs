namespace MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;

public interface IEnableableEntity<TId, TIdValue> : IEntity<TId, TIdValue> where TId : struct, IId<TIdValue>
{
    bool IsEnabled { get; set; }
}