using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OrganizationKinds.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OrganizationKinds.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationKindAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationKindAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OrganizationKinds.CQRS.Query.Paginate;

internal sealed class OrganizationKindPaginateQueryHandler :
    AbstractPaginateQueryHandler<OrganizationKind, OrganizationKindId, Guid, OrganizationKindPaginateQuery, OrganizationKindBasicDto>,
    IRequestHandler<OrganizationKindPaginateQuery, PaginateQueryResultModel<OrganizationKindBasicDto>>
{
    public OrganizationKindPaginateQueryHandler(IOrganizationKindQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }

    protected override Expression<Func<OrganizationKind, bool>>? GlobalSelector => entity => !entity.IsArchived;

    protected override Expression<Func<OrganizationKind, object>> OrderExpression => entity => entity.Priority;
}