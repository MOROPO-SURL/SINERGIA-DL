using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.KeyVariableTraces.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.KeyVariableTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.KeyVariableTraces.CQRS.Query.Paginate
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
