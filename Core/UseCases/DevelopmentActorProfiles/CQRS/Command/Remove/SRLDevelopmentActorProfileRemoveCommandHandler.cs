using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.DevelopmentActorProfiles.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.DevelopmentActorProfileAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.DevelopmentActorProfiles.CQRS.Command.Remove;

internal sealed class SRLDevelopmentActorProfileRemoveCommandHandler :
    AbstractRemoveCommandHandler<SRLDevelopmentActorProfile, DevelopmentActorProfileId, Guid, SRLDevelopmentActorProfileRemoveCommand>,
    IRequestHandler<SRLDevelopmentActorProfileRemoveCommand>
{
    public SRLDevelopmentActorProfileRemoveCommandHandler(ISRLDevelopmentActorProfileCommandRepositoryPort entityCommandRepository, IMapper mapper) : base(entityCommandRepository, mapper)
    {
    }
}
