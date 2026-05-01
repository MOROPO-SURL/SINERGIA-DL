using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PersonTraces.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PersonTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Persons.CQRS.Query.Paginate;

internal sealed class PersonTracePaginateQueryHandler :
    AbstractPaginateQueryHandler<PersonTrace, TraceId, long, PersonTracePaginateQuery, PersonTraceBasicDto>,
    IRequestHandler<PersonTracePaginateQuery, PaginateQueryResultModel<PersonTraceBasicDto>>
{
    public PersonTracePaginateQueryHandler(IPersonTraceQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }

    protected override Expression<Func<PersonTrace, object>> OrderExpression => entity => entity.CreatedAt;

    protected override bool IsOrderDescending => true;
}