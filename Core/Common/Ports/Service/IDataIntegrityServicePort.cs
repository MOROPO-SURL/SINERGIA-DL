using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Ports.Service;

public interface IDataIntegrityServicePort
{
    Task<string> GetEntitySignatureAsync(IPersistenceSignable entity);
}