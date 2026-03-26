namespace MOROPO.GEDET.CAM.Domain.Common.Aggregate.Contract;

public interface IPersistenceSignable
{
    string Signature { get; set; }

    object GetSignableEntityModel();
}
