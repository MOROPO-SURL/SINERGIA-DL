namespace MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;

public interface IPersistenceSignable
{
    string Signature { get; set; }

    object GetSignableEntityModel();
}
