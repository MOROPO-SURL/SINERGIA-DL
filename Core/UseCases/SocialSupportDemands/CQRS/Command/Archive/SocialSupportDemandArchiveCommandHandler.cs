using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialSupportDemands.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.SocialSupportDemandAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.SocialSupportDemandAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialSupportDemands.CQRS.Command.Archive;

internal sealed class SocialSupportDemandArchiveCommandHandler : 
    AbstractArchiveCommandHandler<SocialSupportDemand, SocialSupportDemandId, Guid, SocialSupportDemandArchiveCommand>,
    IRequestHandler<SocialSupportDemandArchiveCommand>
{
    public SocialSupportDemandArchiveCommandHandler(ISocialSupportDemandCommandRepositoryPort entityCommandRepository, IMapper mapper) : 
        base(entityCommandRepository, mapper)
    {
    }
}