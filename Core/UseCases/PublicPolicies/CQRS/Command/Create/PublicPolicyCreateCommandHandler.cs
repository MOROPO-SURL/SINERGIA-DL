using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PublicPolicyAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PublicPolicyAggregate.Values;
using MapsterMapper;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PublicPolicies.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PublicPolicies.Ports.Repository;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PublicPolicies.CQRS.Command.Create;

internal sealed class PublicPolicyCreateCommandHandler : AbstractCreateCommandHandler<PublicPolicy, PublicPolicyId, Guid, PublicPolicyCreateCommand, PublicPolicyDetailDto>, IRequestHandler<PublicPolicyCreateCommand, PublicPolicyDetailDto>
{
    public PublicPolicyCreateCommandHandler(IPublicPolicyCommandRepositoryPort entityCommandRepository, IPublicPolicyQueryRepositoryPort entityQueryRepository, IMapper mapper)
    : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}
