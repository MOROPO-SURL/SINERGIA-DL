namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Intefaces;

public interface IArchivableEntity<TId, TIdValue> : IEntity<TId, TIdValue> where TId : struct, IId<TIdValue>
{
    bool IsArchived { get; set; }
}