using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Interfaces;

public interface IPaginateQuery<TEntity, TId, TIdValue, TDto> : MediatR.IRequest<Models.PaginateQueryResultModel<TDto>>
    where TEntity : IEntity<TId, TIdValue>
    where TId : struct, IId<TIdValue>
    where TDto : DTOs.Interfaces.IDto
{
    public int Page { get; }

    public int Limit { get; }

    public Expression<Func<TEntity, bool>>? Criteria { get; }
}