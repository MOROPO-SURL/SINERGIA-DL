using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.DevelopmentActorProfiles.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.DevelopmentActorProfiles.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.DevelopmentActorProfileAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.DevelopmentActorProfiles.CQRS.Query.Paginate;

internal sealed class NaturalOwnedPDLDevelopmentActorProfilePaginateQueryHandler :
    AbstractPaginateQueryHandler<NaturalOwnedPDLDevelopmentActorProfile, DevelopmentActorProfileId, Guid, NaturalOwnedPDLDevelopmentActorProfilePaginateQuery, DevelopmentActorProfileBasicDto>,
    IRequestHandler<NaturalOwnedPDLDevelopmentActorProfilePaginateQuery, PaginateQueryResultModel<DevelopmentActorProfileBasicDto>>
{
    public NaturalOwnedPDLDevelopmentActorProfilePaginateQueryHandler(INaturalOwnedPDLDevelopmentActorProfileQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }
}