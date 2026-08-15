using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.DevelopmentActorProfiles.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.DevelopmentActorProfiles.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.NaturalOwnedPDLDevelopmentActorProfiles.CQRS.Query.List;

internal sealed class NaturalOwnedPDLDevelopmentActorProfileListQueryHandler :
    AbstractListQueryHandler<NaturalOwnedPDLDevelopmentActorProfile, DevelopmentActorProfileId, Guid, NaturalOwnedPDLDevelopmentActorProfileDetailDto, NaturalOwnedPDLDevelopmentActorProfileListQuery>,
    IRequestHandler<NaturalOwnedPDLDevelopmentActorProfileListQuery, NaturalOwnedPDLDevelopmentActorProfileDetailDto[]>
{
    public NaturalOwnedPDLDevelopmentActorProfileListQueryHandler(INaturalOwnedPDLDevelopmentActorProfileQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }
}