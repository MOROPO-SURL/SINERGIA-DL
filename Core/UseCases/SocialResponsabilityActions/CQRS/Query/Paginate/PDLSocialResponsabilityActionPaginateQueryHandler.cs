using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.SocialResponsabilityActions.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.SocialResponsabilityActions.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.SocialResponsabilityActionAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.SocialResponsabilityActionAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.SocialResponsabilityActions.CQRS.Query.Paginate;

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