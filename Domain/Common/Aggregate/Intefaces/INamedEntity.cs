namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Intefaces;

public interface INamedEntity<TId, TIdValue> : IEntity<TId, TIdValue> where TId : struct, IId<TIdValue>
{
    string Name { get; set; }
}