using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialResponsabilityActions.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.SocialResponsabilityActionAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.SocialResponsabilityActionAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialResponsabilityActions.CQRS.Command.Unarchive;

internal sealed class PDLSocialResponsabilityActionUnarchiveCommandHandler : 
    AbstractUnarchiveCommandHandler<PDLSocialResponsabilityAction, SocialResponsabilityActionId, Guid, PDLSocialResponsabilityActionUnarchiveCommand>,
    IRequestHandler<PDLSocialResponsabilityActionUnarchiveCommand>
{
    public PDLSocialResponsabilityActionUnarchiveCommandHandler(IPDLSocialResponsabilityActionCommandRepositoryPort entityCommandRepository, IMapper mapper)
        : base(entityCommandRepository, mapper)
    {
    }
}