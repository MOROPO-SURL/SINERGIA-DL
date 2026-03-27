namespace MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;

public interface IArchivableEntity<TId> : IEntity<TId>
{
    bool IsArchived { get; set; }
}
