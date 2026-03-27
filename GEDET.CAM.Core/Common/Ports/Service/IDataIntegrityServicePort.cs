using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.GEDET.CAM.Domain.Common.Ports.Service;

public interface IDataIntegrityServicePort
{
    public string GetEntitySignature(IPersistenceSignable entity);
}