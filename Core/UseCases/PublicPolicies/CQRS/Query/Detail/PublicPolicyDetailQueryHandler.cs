using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PublicPolicyAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PublicPolicyAggregate.Values;
using MapsterMapper;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PublicPolicies.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PublicPolicies.Ports.Repository;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PublicPolicies.CQRS.Query.Detail;

internal sealed class PublicPolicyDetailQueryHandler : AbstractDetailQueryHandler<PublicPolicy, PublicPolicyId, Guid, PublicPolicyDetailQuery, PublicPolicyDetailDto>,
IRequestHandler<PublicPolicyDetailQuery, PublicPolicyDetailDto>
{
    public PublicPolicyDetailQueryHandler(IPublicPolicyQueryRepositoryPort publicPolicyQueryRepository, IMapper mapper) : base(publicPolicyQueryRepository, mapper)
    {
    }
}
