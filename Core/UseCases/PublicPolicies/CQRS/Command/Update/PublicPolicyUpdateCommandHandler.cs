using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PublicPolicyAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PublicPolicyAggregate.Values;
using MapsterMapper;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PublicPolicies.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PublicPolicies.Ports.Repository;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PublicPolicies.CQRS.Command.Update;

internal sealed class PublicPolicyUpdateCommandHandler : AbstractUpdateCommandHandler<PublicPolicy, PublicPolicyId, Guid, PublicPolicyUpdateCommand, PublicPolicyDetailDto>,
IRequestHandler<PublicPolicyUpdateCommand, PublicPolicyDetailDto>
{
    public PublicPolicyUpdateCommandHandler(IPublicPolicyCommandRepositoryPort entityCommandRepository, IPublicPolicyQueryRepositoryPort entityQueryRepository, IMapper mapper)
    : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}
