namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Intefaces
{
    public interface IAggregateRoot
    {
    }

    public interface IAggregateRoot<TId, TIdValue> : IAggregateRoot, IEntity<TId, TIdValue> where TId : struct, IId<TIdValue>
    {
    }
}