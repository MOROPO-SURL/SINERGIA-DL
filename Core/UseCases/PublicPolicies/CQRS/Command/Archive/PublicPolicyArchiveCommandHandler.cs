using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PublicPolicyAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PublicPolicyAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PublicPolicies.Ports.Repository;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PublicPolicies.CQRS.Command.Archive;

internal sealed class PublicPolicyArchiveCommandHandler : AbstractArchiveCommandHandler<PublicPolicy, PublicPolicyId, Guid, PublicPolicyArchiveCommand>,
IRequestHandler<PublicPolicyArchiveCommand>
{
    public PublicPolicyArchiveCommandHandler(IPublicPolicyCommandRepositoryPort entityCommandRepository, IPublicPolicyQueryRepositoryPort entityQueryRepository, IMapper mapper) : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}
