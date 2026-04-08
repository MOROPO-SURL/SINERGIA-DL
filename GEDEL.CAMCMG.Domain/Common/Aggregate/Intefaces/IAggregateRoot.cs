namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

public interface IAggregateRoot<TId, TIdValue> : IEntity<TId, TIdValue> where TId : struct, IId<TIdValue>
{
}