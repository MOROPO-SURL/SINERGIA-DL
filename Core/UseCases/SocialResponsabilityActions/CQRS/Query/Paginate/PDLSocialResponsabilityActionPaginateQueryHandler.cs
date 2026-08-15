using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialResponsabilityActions.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialResponsabilityActions.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.SocialResponsabilityActionAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.SocialResponsabilityActionAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialResponsabilityActions.CQRS.Query.Paginate;

internal sealed class PDLSocialResponsabilityActionPaginateQueryHandler :
    AbstractPaginateQueryHandler<PDLSocialResponsabilityAction, SocialResponsabilityActionId, Guid, PDLSocialResponsabilityActionPaginateQuery, PDLSocialResponsabilityActionBasicDto>,
    IRequestHandler<PDLSocialResponsabilityActionPaginateQuery, PaginateQueryResultModel<PDLSocialResponsabilityActionBasicDto>>
{
    public PDLSocialResponsabilityActionPaginateQueryHandler(IPDLSocialResponsabilityActionQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }

    protected override Expression<Func<PDLSocialResponsabilityAction, object>> OrderExpression => entity => entity.At;

    protected override bool IsOrderDescending => true;
}