using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.GEDET.CAM.Domain.Common.Ports.Service;

public interface IDataIntegrityServicePort
{
    Task<string> GetEntitySignatureAsync(IPersistenceSignable entity);
}