using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.SocialSupportDemands.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.SocialSupportDemandAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.SocialSupportDemandAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.SocialSupportDemands.CQRS.Command.Unarchive;

internal sealed class SocialSupportDemandUnarchiveCommandHandler : 
    AbstractUnarchiveCommandHandler<SocialSupportDemand, SocialSupportDemandId, Guid, SocialSupportDemandUnarchiveCommand>,
    IRequestHandler<SocialSupportDemandUnarchiveCommand>
{
    public SocialSupportDemandUnarchiveCommandHandler(ISocialSupportDemandCommandRepositoryPort entityCommandRepository, IMapper mapper)
        : base(entityCommandRepository, mapper)
    {
    }
}