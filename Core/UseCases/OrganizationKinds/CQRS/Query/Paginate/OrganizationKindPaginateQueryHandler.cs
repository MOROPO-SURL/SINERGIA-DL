using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.OrganizationKinds.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.OrganizationKinds.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OrganizationKindAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OrganizationKindAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.OrganizationKinds.CQRS.Query.Paginate;

internal sealed class OrganizationKindPaginateQueryHandler :
    AbstractPaginateQueryHandler<OrganizationKind, OrganizationKindId, Guid, OrganizationKindPaginateQuery, OrganizationKindBasicDto>,
    IRequestHandler<OrganizationKindPaginateQuery, PaginateQueryResultModel<OrganizationKindBasicDto>>
{
    public OrganizationKindPaginateQueryHandler(IOrganizationKindQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }

    protected override Expression<Func<OrganizationKind, object>> OrderExpression => entity => entity.Priority;
}