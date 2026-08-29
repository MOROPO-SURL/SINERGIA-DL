namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Intefaces;

public interface IId<TIdValue>
{
    public TIdValue Value { get; }
}