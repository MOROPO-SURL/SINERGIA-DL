namespace MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;

public interface IId<TIdValue>
{
    public TIdValue Value { get; }
}