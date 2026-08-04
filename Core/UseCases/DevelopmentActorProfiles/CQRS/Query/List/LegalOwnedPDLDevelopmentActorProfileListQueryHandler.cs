using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.DevelopmentActorProfiles.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.DevelopmentActorProfiles.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.LegalOwnedPDLDevelopmentActorProfiles.CQRS.Query.List;

internal sealed class LegalOwnedPDLDevelopmentActorProfileListQueryHandler :
    AbstractListQueryHandler<LegalOwnedPDLDevelopmentActorProfile, DevelopmentActorProfileId, Guid, LegalOwnedPDLDevelopmentActorProfileDetailDto, LegalOwnedPDLDevelopmentActorProfileListQuery>,
    IRequestHandler<LegalOwnedPDLDevelopmentActorProfileListQuery, LegalOwnedPDLDevelopmentActorProfileDetailDto[]>
{
    public LegalOwnedPDLDevelopmentActorProfileListQueryHandler(ILegalOwnedPDLDevelopmentActorProfileQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }
}