using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PublicPolicyAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PublicPolicyAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PublicPolicies.Ports.Repository;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PublicPolicies.CQRS.Command.Unarchive;

internal sealed class PublicPolicyUnarchiveCommandHandler : AbstractUnarchiveCommandHandler<PublicPolicy, PublicPolicyId, Guid, PublicPolicyUnarchiveCommand>,
IRequestHandler<PublicPolicyUnarchiveCommand>
{
    public PublicPolicyUnarchiveCommandHandler(IPublicPolicyCommandRepositoryPort entityCommandRepository, IPublicPolicyQueryRepositoryPort entityQueryRepository, IMapper mapper) : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}
