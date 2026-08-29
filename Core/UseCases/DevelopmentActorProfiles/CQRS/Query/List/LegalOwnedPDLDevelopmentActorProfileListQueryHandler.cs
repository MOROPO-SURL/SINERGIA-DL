using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.DevelopmentActorProfiles.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.DevelopmentActorProfiles.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.DevelopmentActorProfileAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.LegalOwnedPDLDevelopmentActorProfiles.CQRS.Query.List;

internal sealed class LegalOwnedPDLDevelopmentActorProfileListQueryHandler :
    AbstractListQueryHandler<LegalOwnedPDLDevelopmentActorProfile, DevelopmentActorProfileId, Guid, LegalOwnedPDLDevelopmentActorProfileDetailDto, LegalOwnedPDLDevelopmentActorProfileListQuery>,
    IRequestHandler<LegalOwnedPDLDevelopmentActorProfileListQuery, LegalOwnedPDLDevelopmentActorProfileDetailDto[]>
{
    public LegalOwnedPDLDevelopmentActorProfileListQueryHandler(ILegalOwnedPDLDevelopmentActorProfileQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }
}