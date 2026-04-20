using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PublicPolicyAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PublicPolicyAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PublicPolicys.DTOs;
using MapsterMapper;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PublicPolicys.Ports.Repository;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PublicPolicys.CQRS.Command.Create;

internal sealed class PublicPolicyCreateCommandHandler: AbstractCreateCommandHandler<PublicPolicy, PublicPolicyId, Guid, PublicPolicyCreateCommand, PublicPolicyDetailDto>, IRequestHandler<PublicPolicyCreateCommand, PublicPolicyDetailDto>
{
    public PublicPolicyCreateCommandHandler(IPublicPolicyCommandRepositoryPort entityCommandRepository, IPublicPolicyQueryRepositoryPort entityQueryRepository, IMapper mapper)
    : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}
