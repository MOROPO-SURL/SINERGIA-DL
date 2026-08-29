using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.SocialSupportDemands.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.SocialSupportDemandAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.SocialSupportDemandAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.SocialSupportDemands.CQRS.Command.Archive;

internal sealed class SocialSupportDemandArchiveCommandHandler : 
    AbstractArchiveCommandHandler<SocialSupportDemand, SocialSupportDemandId, Guid, SocialSupportDemandArchiveCommand>,
    IRequestHandler<SocialSupportDemandArchiveCommand>
{
    public SocialSupportDemandArchiveCommandHandler(ISocialSupportDemandCommandRepositoryPort entityCommandRepository, IMapper mapper) : 
        base(entityCommandRepository, mapper)
    {
    }
}