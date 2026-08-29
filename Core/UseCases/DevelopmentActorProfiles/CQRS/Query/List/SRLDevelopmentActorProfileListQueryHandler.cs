using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.DevelopmentActorProfiles.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.DevelopmentActorProfiles.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.DevelopmentActorProfileAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.SRLDevelopmentActorProfiles.CQRS.Query.List;

internal sealed class SRLDevelopmentActorProfileListQueryHandler :
    AbstractListQueryHandler<SRLDevelopmentActorProfile, DevelopmentActorProfileId, Guid, SRLDevelopmentActorProfileDetailDto, SRLDevelopmentActorProfileListQuery>,
    IRequestHandler<SRLDevelopmentActorProfileListQuery, SRLDevelopmentActorProfileDetailDto[]>
{
    public SRLDevelopmentActorProfileListQueryHandler(ISRLDevelopmentActorProfileQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }
}