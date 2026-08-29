using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.DevelopmentActorProfiles.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.DevelopmentActorProfiles.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.DevelopmentActorProfileAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.DevelopmentActorProfiles.CQRS.Query.Paginate;

internal sealed class LegalOwnedPDLDevelopmentActorProfilePaginateQueryHandler :
    AbstractPaginateQueryHandler<LegalOwnedPDLDevelopmentActorProfile, DevelopmentActorProfileId, Guid, LegalOwnedPDLDevelopmentActorProfilePaginateQuery, DevelopmentActorProfileBasicDto>,
    IRequestHandler<LegalOwnedPDLDevelopmentActorProfilePaginateQuery, PaginateQueryResultModel<DevelopmentActorProfileBasicDto>>
{
    public LegalOwnedPDLDevelopmentActorProfilePaginateQueryHandler(ILegalOwnedPDLDevelopmentActorProfileQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }
}