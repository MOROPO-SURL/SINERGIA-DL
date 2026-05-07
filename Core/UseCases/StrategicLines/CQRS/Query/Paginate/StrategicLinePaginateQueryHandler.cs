using Mapster;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.Ports.Repository;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.CQRS.Query.Paginate;

internal sealed class StrategicLinePaginateQueryHandler : IRequestHandler<StrategicLinePaginateQuery, PaginateQueryResultModel<StrategicLineBasicDto>>
{
    private readonly IStrategicLineQueryRepositoryPort entityQueryRepository;

    public StrategicLinePaginateQueryHandler(IStrategicLineQueryRepositoryPort entityQueryRepository) 
    {
        this.entityQueryRepository = entityQueryRepository;
    }

    public async Task<PaginateQueryResultModel<StrategicLineBasicDto>> Handle(StrategicLinePaginateQuery request, CancellationToken cancellationToken)
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

        StrategicLineBasicDto[] result = count <= 0 ? [] : [.. entityQueryRepository.GetPageQueryable(page, request.Limit, request.Criteria).ProjectToType<StrategicLineBasicDto>()];

        return new PaginateQueryResultModel<StrategicLineBasicDto>
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