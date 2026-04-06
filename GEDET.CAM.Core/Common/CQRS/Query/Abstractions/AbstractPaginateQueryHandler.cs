using Mapster;
using MediatR;
using MOROPO.GEDET.CAM.Core.Common.CQRS.Query.Interfaces;
using MOROPO.GEDET.CAM.Core.Common.DTOs.Interfaces;
using MOROPO.GEDET.CAM.Core.Common.Models;
using MOROPO.GEDET.CAM.Core.Common.Ports.Repository;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.GEDET.CAM.Core.UseCases.Roles.CQRS.Query.Paginate;

internal abstract class AbstractPaginateQueryHandler<TEntity, TId, TIdValue, TPaginateQuery, TBasicDto> : IRequestHandler<TPaginateQuery, PaginateQueryResultModel<TBasicDto>>
    where TEntity : class, IEntity<TId, TIdValue>
    where TId : struct, IId<TIdValue>
    where TPaginateQuery : IPaginateQuery<TEntity, TId, TIdValue, TBasicDto>
    where TBasicDto : IDto
{
    private readonly IEntityQueryRepositoryPort<TEntity, TId, TIdValue> entityQueryRepository;

    protected AbstractPaginateQueryHandler(IEntityQueryRepositoryPort<TEntity, TId, TIdValue> entityQueryRepository)
    {
        this.entityQueryRepository = entityQueryRepository;
    }

    public async Task<PaginateQueryResultModel<TBasicDto>> Handle(TPaginateQuery request, CancellationToken cancellationToken)
    {
        int count = request.Criteria == null ? await entityQueryRepository.CountAsync() : await entityQueryRepository.CountAsync(request.Criteria);

        int rest = count % request.Limit;

        int maxPageCount = count / request.Limit;

        if (rest > 0) maxPageCount += 1;

        int page = request.Page;

        if (request.Page < 0 || request.Page > maxPageCount)
        {
            page = 1;
        }

        TBasicDto[] result = count <= 0 ? [] : [.. entityQueryRepository.GetPageQueryable(page, request.Limit, request.Criteria).ProjectToType<TBasicDto>()];

        return new PaginateQueryResultModel<TBasicDto>
        {
            Page = page,
            Limit = request.Limit,
            Items = result,
            HasPrevious = page > 1,
            HasNext = page < maxPageCount,
            MaxPageCount = maxPageCount,
        };
    }
}