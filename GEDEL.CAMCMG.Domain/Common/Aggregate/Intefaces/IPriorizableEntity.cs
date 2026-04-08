namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

public interface IPriorizableEntity<TId, TIdValue> : IEntity<TId, TIdValue> where TId : struct, IId<TIdValue>
{
    int Priority { get; set; }
}