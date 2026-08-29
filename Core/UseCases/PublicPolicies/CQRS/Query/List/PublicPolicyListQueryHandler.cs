using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PublicPolicies.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PublicPolicies.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PublicPolicyAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PublicPolicyAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PublicPolicies.CQRS.Query.List;

internal sealed class PublicPolicyListQueryHandler :
    AbstractListQueryHandler<PublicPolicy, PublicPolicyId, Guid, PublicPolicyDetailDto, PublicPolicyListQuery>,
    IRequestHandler<PublicPolicyListQuery, PublicPolicyDetailDto[]>
{
    public PublicPolicyListQueryHandler(IPublicPolicyQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }
}