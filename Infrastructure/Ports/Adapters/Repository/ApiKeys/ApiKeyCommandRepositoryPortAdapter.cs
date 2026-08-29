using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.ApiKeys.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ApiKeyAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ApiKeyAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.ApiKeys;

internal sealed class ApiKeyCommandRepositoryPortAdapter :
    AbstractEntityCommandRepositoryPortAdapter<ApiKey, ApiKeyId, Guid>,
    IApiKeyCommandRepositoryPort
{
    public ApiKeyCommandRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }
}
