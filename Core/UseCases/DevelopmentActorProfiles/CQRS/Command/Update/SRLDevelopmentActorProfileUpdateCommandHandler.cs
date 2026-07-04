using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.DevelopmentActorProfiles.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.DevelopmentActorProfiles.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.DevelopmentActorProfiles.CQRS.Command.Update;

internal sealed class SRLDevelopmentActorProfileUpdateCommandHandler :
    AbstractUpdateCommandHandler<SRLDevelopmentActorProfile, DevelopmentActorProfileId, Guid, SRLDevelopmentActorProfileUpdateCommand, SRLDevelopmentActorProfileDetailDto>,
    IRequestHandler<SRLDevelopmentActorProfileUpdateCommand, SRLDevelopmentActorProfileDetailDto>
{
    public SRLDevelopmentActorProfileUpdateCommandHandler(ISRLDevelopmentActorProfileCommandRepositoryPort entityCommandRepository, ISRLDevelopmentActorProfileQueryRepositoryPort entityQueryRepository, IMapper mapper) : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}