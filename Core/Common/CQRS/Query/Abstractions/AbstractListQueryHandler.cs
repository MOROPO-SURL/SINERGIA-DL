using Mapster;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Intefaces;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;

internal abstract class AbstractListQueryHandler<TEntity, TId, TIdValue, TDto, TListQuery>
    where TEntity : class, IEntity<TId, TIdValue>
    where TId : struct, IId<TIdValue>
    where TDto : IDto
    where TListQuery : IListQuery<TEntity, TId, TIdValue, TDto>, IRequest<TDto[]>
{
    private readonly IEntityQueryRepositoryPort<TEntity, TId, TIdValue> entityQueryRepository;

    protected AbstractListQueryHandler(IEntityQueryRepositoryPort<TEntity, TId, TIdValue> entityQueryRepository)
    {
        this.entityQueryRepository = entityQueryRepository;
    }

    public Task<TDto[]> Handle(TListQuery request, CancellationToken cancellationToken)
    {
        if (request.Criteria != null)
        {
            return Task.FromResult(entityQueryRepository!.GetFindByQueryable(request.Criteria!).Select(entity => entity.Adapt<TDto>()).ToArray());
        }

        return Task.FromResult(entityQueryRepository!.GetAllQueryable().Select(entity => entity.Adapt<TDto>()).ToArray());
    }

    protected virtual Expression<Func<TEntity, object>> OrderExpression => entity => entity.Id;

    protected virtual bool IsOrderDescending => false;
}