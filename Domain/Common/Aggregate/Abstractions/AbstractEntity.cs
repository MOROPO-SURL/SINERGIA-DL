using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Abstractions;

public abstract class AbstractEntity<TId, TIdValue> : IEntity<TId, TIdValue> where TId : struct, IId<TIdValue>
{
    protected AbstractEntity(TId id)
    {
        Id = id;
    }

    public TId Id { get; set; }
}