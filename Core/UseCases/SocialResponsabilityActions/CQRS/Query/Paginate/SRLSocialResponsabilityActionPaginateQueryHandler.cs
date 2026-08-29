using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.SocialResponsabilityActions.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.SocialResponsabilityActions.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.SocialResponsabilityActionAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.SocialResponsabilityActionAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.SocialResponsabilityActions.CQRS.Query.Paginate;

internal sealed class SRLSocialResponsabilityActionPaginateQueryHandler :
    AbstractPaginateQueryHandler<SRLSocialResponsabilityAction, SocialResponsabilityActionId, Guid, SRLSocialResponsabilityActionPaginateQuery, SRLSocialResponsabilityActionBasicDto>,
    IRequestHandler<SRLSocialResponsabilityActionPaginateQuery, PaginateQueryResultModel<SRLSocialResponsabilityActionBasicDto>>
{
    public SRLSocialResponsabilityActionPaginateQueryHandler(ISRLSocialResponsabilityActionQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }

    protected override Expression<Func<SRLSocialResponsabilityAction, object>> OrderExpression => entity => entity.At;

    protected override bool IsOrderDescending => true;
}