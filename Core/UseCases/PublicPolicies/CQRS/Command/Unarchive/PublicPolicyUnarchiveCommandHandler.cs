using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PublicPolicyAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PublicPolicyAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PublicPolicies.Ports.Repository;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PublicPolicies.CQRS.Command.Unarchive;

internal sealed class PublicPolicyUnarchiveCommandHandler : AbstractUnarchiveCommandHandler<PublicPolicy, PublicPolicyId, Guid, PublicPolicyUnarchiveCommand>,
IRequestHandler<PublicPolicyUnarchiveCommand>
{
    public PublicPolicyUnarchiveCommandHandler(IPublicPolicyCommandRepositoryPort entityCommandRepository, IMapper mapper) : base(entityCommandRepository, mapper)
    {
    }
}
