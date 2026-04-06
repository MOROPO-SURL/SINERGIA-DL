using MapsterMapper;
using MediatR;
using MOROPO.GEDET.CAM.Core.Common.CQRS.Query.Interfaces;
using MOROPO.GEDET.CAM.Core.Common.DTOs.Interfaces;
using MOROPO.GEDET.CAM.Core.Common.Ports.Repository;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.GEDET.CAM.Core.UseCases.Roles.CQRS.Query.Detail;

internal abstract class AbstractDetailQueryHandler<TEntity, TId, TIdValue, TDetailQuery, TDetailDto> : IRequestHandler<TDetailQuery, TDetailDto>
    where TEntity : class, IEntity<TId, TIdValue>
    where TId : struct, IId<TIdValue>
    where TDetailQuery : IDetailQuery<TId, TIdValue, TDetailDto>
    where TDetailDto : IDetailDto
{
    private readonly IEntityQueryRepositoryPort<TEntity, TId, TIdValue> entityQueryRepository;
    private readonly IMapper mapper;

    protected AbstractDetailQueryHandler(IEntityQueryRepositoryPort<TEntity, TId, TIdValue> entityQueryRepository, IMapper mapper)
    {
        this.entityQueryRepository = entityQueryRepository;
        this.mapper = mapper;
    }

    public async Task<TDetailDto> Handle(TDetailQuery request, CancellationToken cancellationToken)
    {
        var entity = await entityQueryRepository.GetAsync(mapper.Map<TId>(request.Id!));

        return mapper.Map<TDetailDto>(entity);
    }
}