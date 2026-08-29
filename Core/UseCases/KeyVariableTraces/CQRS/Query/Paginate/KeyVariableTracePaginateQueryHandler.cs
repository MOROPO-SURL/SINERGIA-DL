using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.KeyVariableTraces.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.KeyVariableTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.KeyVariableTraces.CQRS.Query.Paginate
{
    internal sealed class KeyVariableTracePaginateQueryHandler :
AbstractPaginateQueryHandler<KeyVariableTrace, TraceId, long, KeyVariableTracePaginateQuery, KeyVariableTraceBasicDto>,
IRequestHandler<KeyVariableTracePaginateQuery, PaginateQueryResultModel<KeyVariableTraceBasicDto>>
    {
        public KeyVariableTracePaginateQueryHandler(IKeyVariableTraceQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
        {
        }

        protected override Expression<Func<KeyVariableTrace, object>> OrderExpression => entity => entity.CreatedAt;

        protected override bool IsOrderDescending => true;
    }
}
