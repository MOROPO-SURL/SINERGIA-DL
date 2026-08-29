using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.KeyVariables.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.KeyVariables.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.KeyVariableAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.KeyVariableAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.KeyVariables.CQRS.Query.Paginate;

internal sealed class KeyVariablePaginateQueryHandler :
    AbstractPaginateQueryHandler<KeyVariable, KeyVariableId, Guid, KeyVariablePaginateQuery, KeyVariableBasicDto>,
    IRequestHandler<KeyVariablePaginateQuery, PaginateQueryResultModel<KeyVariableBasicDto>>
{
    public KeyVariablePaginateQueryHandler(IKeyVariableQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }

    protected override Expression<Func<KeyVariable, object>> OrderExpression => entity => entity.Priority;
}