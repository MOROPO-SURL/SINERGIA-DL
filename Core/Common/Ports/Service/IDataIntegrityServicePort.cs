using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Ports.Service;

public interface IDataIntegrityServicePort
{
    Task<string> GetEntitySignatureAsync(IPersistenceSignable entity);
}