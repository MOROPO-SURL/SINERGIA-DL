using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.SocialSupportDemands.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.SocialSupportDemandAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.SocialSupportDemandAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.SocialSupportDemands.CQRS.Command.Remove;

internal sealed class SocialSupportDemandRemoveCommandHandler : 
    AbstractRemoveCommandHandler<SocialSupportDemand, SocialSupportDemandId, Guid, SocialSupportDemandRemoveCommand>,
    IRequestHandler<SocialSupportDemandRemoveCommand>
{
    public SocialSupportDemandRemoveCommandHandler(ISocialSupportDemandCommandRepositoryPort entityCommandRepository, IMapper mapper)
        : base(entityCommandRepository, mapper)
    {
    }
}