using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Repositories.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PublicPolicyAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PublicPolicyAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PublicPolicies.Ports.Repository;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.PublicPolicies;

internal sealed class PublicPolicyQueryRepositoryPortAdapter : AbstractEntityQueryRepositoryPortAdapter<PublicPolicy, PublicPolicyId, Guid>, IPublicPolicyQueryRepositoryPort
{
    public PublicPolicyQueryRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }
}
