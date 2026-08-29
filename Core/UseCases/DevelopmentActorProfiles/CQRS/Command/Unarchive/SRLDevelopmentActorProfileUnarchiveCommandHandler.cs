using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.DevelopmentActorProfiles.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.DevelopmentActorProfileAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.DevelopmentActorProfiles.CQRS.Command.Unarchive;

internal sealed class SRLDevelopmentActorProfileUnarchiveCommandHandler :
    AbstractUnarchiveCommandHandler<SRLDevelopmentActorProfile, DevelopmentActorProfileId, Guid, SRLDevelopmentActorProfileUnarchiveCommand>,
    IRequestHandler<SRLDevelopmentActorProfileUnarchiveCommand>
{
    public SRLDevelopmentActorProfileUnarchiveCommandHandler(ISRLDevelopmentActorProfileCommandRepositoryPort entityCommandRepository, IMapper mapper) : base(entityCommandRepository, mapper)
    {
    }
}
