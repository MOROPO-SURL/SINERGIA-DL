using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialResponsabilityActions.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.SocialResponsabilityActionAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.SocialResponsabilityActionAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialResponsabilityActions.CQRS.Command.Archive;

internal sealed class SRLSocialResponsabilityActionArchiveCommandHandler : 
    AbstractArchiveCommandHandler<SRLSocialResponsabilityAction, SocialResponsabilityActionId, Guid, SRLSocialResponsabilityActionArchiveCommand>,
    IRequestHandler<SRLSocialResponsabilityActionArchiveCommand>
{
    public SRLSocialResponsabilityActionArchiveCommandHandler(ISRLSocialResponsabilityActionCommandRepositoryPort entityCommandRepository, IMapper mapper) : 
        base(entityCommandRepository, mapper)
    {
    }
}