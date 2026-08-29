using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.SocialResponsabilityActions.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.SocialResponsabilityActionAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.SocialResponsabilityActionAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.SocialResponsabilityActions.CQRS.Command.Unarchive;

internal sealed class SRLSocialResponsabilityActionUnarchiveCommandHandler : 
    AbstractUnarchiveCommandHandler<SRLSocialResponsabilityAction, SocialResponsabilityActionId, Guid, SRLSocialResponsabilityActionUnarchiveCommand>,
    IRequestHandler<SRLSocialResponsabilityActionUnarchiveCommand>
{
    public SRLSocialResponsabilityActionUnarchiveCommandHandler(ISRLSocialResponsabilityActionCommandRepositoryPort entityCommandRepository, IMapper mapper)
        : base(entityCommandRepository, mapper)
    {
    }
}