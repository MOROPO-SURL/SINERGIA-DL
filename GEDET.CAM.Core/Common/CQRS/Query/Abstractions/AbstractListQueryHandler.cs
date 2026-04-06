using Mapster;
using MediatR;
using MOROPO.GEDET.CAM.Core.Common.CQRS.Query.Interfaces;
using MOROPO.GEDET.CAM.Core.Common.DTOs.Interfaces;
using MOROPO.GEDET.CAM.Core.Common.Ports.Repository;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.GEDET.CAM.Core.UseCases.Roles.CQRS.Query.List;

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
            return Task.FromResult(entityQueryRepository!.GetFindByQueryable(request.Criteria!).ProjectToType<TDto>().ToArray());
        }

        return Task.FromResult(entityQueryRepository!.GetAllQueryable().ProjectToType<TDto>().ToArray());
    }
}