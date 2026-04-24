using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PublicPolicys.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PublicPolicys.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PublicPolicyAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PublicPolicyAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PublicPolicys.CQRS.Query.List;

internal sealed class PublicPolicyListQueryHandler :
    AbstractListQueryHandler<PublicPolicy, PublicPolicyId, Guid, PublicPolicyDetailDto, PublicPolicyListQuery>,
    IRequestHandler<PublicPolicyListQuery, PublicPolicyDetailDto[]>
{
    public PublicPolicyListQueryHandler(IPublicPolicyQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }
}