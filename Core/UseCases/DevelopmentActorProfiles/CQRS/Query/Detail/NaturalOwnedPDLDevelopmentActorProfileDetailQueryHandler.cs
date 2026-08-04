using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.DevelopmentActorProfiles.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.DevelopmentActorProfiles.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.DevelopmentActorProfiles.CQRS.Query.Detail;

internal sealed class NaturalOwnedPDLDevelopmentActorProfileDetailQueryHandler :
    AbstractDetailQueryHandler<NaturalOwnedPDLDevelopmentActorProfile, DevelopmentActorProfileId, Guid, NaturalOwnedPDLDevelopmentActorProfileDetailQuery, NaturalOwnedPDLDevelopmentActorProfileDetailDto>,
    IRequestHandler<NaturalOwnedPDLDevelopmentActorProfileDetailQuery, NaturalOwnedPDLDevelopmentActorProfileDetailDto>
{
    public NaturalOwnedPDLDevelopmentActorProfileDetailQueryHandler(INaturalOwnedPDLDevelopmentActorProfileQueryRepositoryPort entityQueryRepository, IMapper mapper) : base(entityQueryRepository, mapper)
    {
    }
}