using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.SocialResponsabilityActions.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.SocialResponsabilityActionAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.SocialResponsabilityActionAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.SocialResponsabilityActions.CQRS.Command.Remove;

internal sealed class SRLSocialResponsabilityActionRemoveCommandHandler : 
    AbstractRemoveCommandHandler<SRLSocialResponsabilityAction, SocialResponsabilityActionId, Guid, SRLSocialResponsabilityActionRemoveCommand>,
    IRequestHandler<SRLSocialResponsabilityActionRemoveCommand>
{
    public SRLSocialResponsabilityActionRemoveCommandHandler(ISRLSocialResponsabilityActionCommandRepositoryPort entityCommandRepository, IMapper mapper)
        : base(entityCommandRepository, mapper)
    {
    }
}