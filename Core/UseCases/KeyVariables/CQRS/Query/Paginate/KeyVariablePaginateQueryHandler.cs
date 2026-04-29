using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.KeyVariables.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.KeyVariables.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.KeyVariableAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.KeyVariableAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.KeyVariables.CQRS.Query.Paginate;

internal sealed class KeyVariablePaginateQueryHandler :
    AbstractPaginateQueryHandler<KeyVariable, KeyVariableId, Guid, KeyVariablePaginateQuery, KeyVariableBasicDto>,
    IRequestHandler<KeyVariablePaginateQuery, PaginateQueryResultModel<KeyVariableBasicDto>>
{
    public KeyVariablePaginateQueryHandler(IKeyVariableQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }

    protected override Expression<Func<KeyVariable, object>> OrderExpression => entity => entity.Priority;
}