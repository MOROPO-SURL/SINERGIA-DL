namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

public interface IEntity<TId, TIdValue> where TId : IId<TIdValue>
{
    TId Id { get; }
}
