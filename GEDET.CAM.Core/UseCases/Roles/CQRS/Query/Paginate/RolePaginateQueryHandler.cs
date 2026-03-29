using Mapster;
using MapsterMapper;
using MediatR;
using MOROPO.GEDET.CAM.Core.Common.Models;
using MOROPO.GEDET.CAM.Core.UseCases.Roles.DTOs;
using MOROPO.GEDET.CAM.Core.UseCases.Roles.Ports.Repository;

namespace MOROPO.GEDET.CAM.Core.UseCases.Roles.CQRS.Query.Paginate;

internal class RolePaginateQueryHandler : IRequestHandler<RolePaginateQuery, PaginateQueryResultModel<RoleEssentialDto>>
{
    private readonly IRoleQueryRepositoryPort roleQueryRepository;
    private readonly IMapper mapper;

    public RolePaginateQueryHandler(IRoleQueryRepositoryPort roleQueryRepository, IMapper mapper)
    {
        this.roleQueryRepository = roleQueryRepository;
        this.mapper = mapper;
    }

    public async Task<PaginateQueryResultModel<RoleEssentialDto>> Handle(RolePaginateQuery query, CancellationToken cancellationToken)
    {
        int count = await roleQueryRepository.CountAsync();

        int rest = count % query.Limit;

        int maxPageCount = count / query.Limit;

        if (rest > 0) maxPageCount += 1;

        int page = query.Page;

        if (query.Page < 0 || query.Page > maxPageCount)
        {
            page = 1;
        }

        RoleEssentialDto[] result = count <= 0 ? [] : [.. roleQueryRepository.GetPageQueryable(page, query.Limit).ProjectToType<RoleEssentialDto>()];

        return new PaginateQueryResultModel<RoleEssentialDto>
        {
            Page = page,
            Limit = query.Limit,
            Items = result,
            HasPrevious = page > 1,
            HasNext = page < maxPageCount,
            MaxPageCount = maxPageCount,
        };
    }
}