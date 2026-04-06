using Mapster;
using MediatR;
using MOROPO.GEDET.CAM.Core.Common.Models;
using MOROPO.GEDET.CAM.Core.UseCases.Roles.DTOs;
using MOROPO.GEDET.CAM.Core.UseCases.Roles.Ports.Repository;

namespace MOROPO.GEDET.CAM.Core.UseCases.Roles.CQRS.Query.Paginate;

internal class AbstractPaginateQueryHandler : IRequestHandler<RolePaginateQuery, PaginateQueryResultModel<RoleBasicDto>>
{
    private readonly IRoleQueryRepositoryPort entityQueryRepository;

    public AbstractPaginateQueryHandler(IRoleQueryRepositoryPort roleQueryRepository)
    {
        this.entityQueryRepository = roleQueryRepository;
    }

    public async Task<PaginateQueryResultModel<RoleBasicDto>> Handle(RolePaginateQuery request, CancellationToken cancellationToken)
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

        RoleBasicDto[] result = count <= 0 ? [] : [.. entityQueryRepository.GetPageQueryable(page, request.Limit, request.Criteria).ProjectToType<RoleBasicDto>()];

        return new PaginateQueryResultModel<RoleBasicDto>
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