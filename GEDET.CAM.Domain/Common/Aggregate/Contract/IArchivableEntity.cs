namespace MOROPO.GEDET.CAM.Domain.Common.Aggregate.Contract;

public interface IArchivableEntity<TId> : IEntity<TId>
{
    bool IsArchived { get; set; }
}
