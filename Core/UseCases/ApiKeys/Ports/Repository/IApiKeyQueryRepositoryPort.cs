using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ApiKeyAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ApiKeyAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.ApiKeys.Ports.Repository;

public interface IApiKeyQueryRepositoryPort : IEntityQueryRepositoryPort<ApiKey, ApiKeyId, Guid>
{
}
