namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

public interface IId<TIdValue>
{
    public TIdValue Value { get; }
}