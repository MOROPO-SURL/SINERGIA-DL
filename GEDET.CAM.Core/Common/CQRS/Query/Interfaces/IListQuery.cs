using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;
using System.Linq.Expressions;

namespace MOROPO.GEDET.CAM.Core.Common.CQRS.Query.Interfaces;

public interface IListQuery<TEntity, TId, TIdValue, TDto> : MediatR.IRequest<TDto[]>
    where TEntity : class, IEntity<TId, TIdValue>
    where TId : struct, IId<TIdValue>
    where TDto : DTOs.Interfaces.IDto
{
    public Expression<Func<TEntity, bool>>? Criteria { get; }
}