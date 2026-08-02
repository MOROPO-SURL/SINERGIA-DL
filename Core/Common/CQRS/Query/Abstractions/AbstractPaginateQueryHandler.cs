using Mapster;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;

internal abstract class AbstractPaginateQueryHandler<TEntity, TId, TIdValue, TPaginateQuery, TDto> : IRequestHandler<TPaginateQuery, PaginateQueryResultModel<TDto>>
    where TEntity : class, IEntity<TId, TIdValue>
    where TId : struct, IId<TIdValue>
    where TPaginateQuery : IPaginateQuery<TEntity, TId, TIdValue, TDto>
    where TDto : IDto
{
    private readonly IEntityQueryRepositoryPort<TEntity, TId, TIdValue> entityQueryRepository;

    protected AbstractPaginateQueryHandler(IEntityQueryRepositoryPort<TEntity, TId, TIdValue> entityQueryRepository)
    {
        this.entityQueryRepository = entityQueryRepository;
    }

    public async Task<PaginateQueryResultModel<TDto>> Handle(TPaginateQuery request, CancellationToken cancellationToken)
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

        TDto[] result = count <= 0 ? [] : [.. entityQueryRepository.GetPageQueryable(page, request.Limit, OrderExpression, IsOrderDescending, request.Criteria).Select(entity => entity.Adapt<TDto>())];

        return new PaginateQueryResultModel<TDto>
        {
            Page = page,
            Limit = request.Limit,
            Items = result,
            HasPrevious = page > 1,
            HasNext = page < maxPageCount,
            MaxPageCount = maxPageCount,
        };
    }

    protected virtual Expression<Func<TEntity, object>> OrderExpression => entity => entity.Id;

    protected virtual bool IsOrderDescending => false;
}