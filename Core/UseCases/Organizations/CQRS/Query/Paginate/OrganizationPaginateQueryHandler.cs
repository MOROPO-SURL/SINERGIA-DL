using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Organizations.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Organizations.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OrganizationAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OrganizationAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Organizations.CQRS.Query.Paginate;

internal sealed class OrganizationPaginateQueryHandler :
    AbstractPaginateQueryHandler<Organization, OrganizationId, Guid, OrganizationPaginateQuery, OrganizationBasicDto>,
    IRequestHandler<OrganizationPaginateQuery, PaginateQueryResultModel<OrganizationBasicDto>>
{
    public OrganizationPaginateQueryHandler(IOrganizationQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }

    protected override Expression<Func<Organization, object>> OrderExpression => entity => entity.Priority;
}