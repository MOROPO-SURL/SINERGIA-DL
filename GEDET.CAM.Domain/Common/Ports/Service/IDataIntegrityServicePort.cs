using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Contract;

namespace MOROPO.GEDET.CAM.Domain.Common.Ports.Service;

public interface IDataIntegrityServicePort
{
    public string GetEntitySignature(IPersistenceSignable entity);
}