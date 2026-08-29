using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.DevelopmentActorProfiles.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.DevelopmentActorProfiles.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.DevelopmentActorProfileAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.NaturalOwnedPDLDevelopmentActorProfiles.CQRS.Query.List;

internal sealed class NaturalOwnedPDLDevelopmentActorProfileListQueryHandler :
    AbstractListQueryHandler<NaturalOwnedPDLDevelopmentActorProfile, DevelopmentActorProfileId, Guid, NaturalOwnedPDLDevelopmentActorProfileDetailDto, NaturalOwnedPDLDevelopmentActorProfileListQuery>,
    IRequestHandler<NaturalOwnedPDLDevelopmentActorProfileListQuery, NaturalOwnedPDLDevelopmentActorProfileDetailDto[]>
{
    public NaturalOwnedPDLDevelopmentActorProfileListQueryHandler(INaturalOwnedPDLDevelopmentActorProfileQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }
}