using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PublicPolicyAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PublicPolicyAggregate.Values;
using MapsterMapper;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PublicPolicies.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PublicPolicies.Ports.Repository;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PublicPolicies.CQRS.Query.Detail;

internal sealed class PublicPolicyDetailQueryHandler : AbstractDetailQueryHandler<PublicPolicy, PublicPolicyId, Guid, PublicPolicyDetailQuery, PublicPolicyDetailDto>,
IRequestHandler<PublicPolicyDetailQuery, PublicPolicyDetailDto>
{
    public PublicPolicyDetailQueryHandler(IPublicPolicyQueryRepositoryPort publicPolicyQueryRepository, IMapper mapper) : base(publicPolicyQueryRepository, mapper)
    {
    }
}
