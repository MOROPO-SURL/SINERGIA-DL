using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.DevelopmentActorProfiles.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.DevelopmentActorProfiles.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.DevelopmentActorProfileAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.DevelopmentActorProfiles.CQRS.Query.Detail;

internal sealed class LegalOwnedPDLDevelopmentActorProfileDetailQueryHandler :
    AbstractDetailQueryHandler<LegalOwnedPDLDevelopmentActorProfile, DevelopmentActorProfileId, Guid, LegalOwnedPDLDevelopmentActorProfileDetailQuery, LegalOwnedPDLDevelopmentActorProfileDetailDto>,
    IRequestHandler<LegalOwnedPDLDevelopmentActorProfileDetailQuery, LegalOwnedPDLDevelopmentActorProfileDetailDto>
{
    public LegalOwnedPDLDevelopmentActorProfileDetailQueryHandler(ILegalOwnedPDLDevelopmentActorProfileQueryRepositoryPort entityQueryRepository, IMapper mapper) : base(entityQueryRepository, mapper)
    {
    }
}