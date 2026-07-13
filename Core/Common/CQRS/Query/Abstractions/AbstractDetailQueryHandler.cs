using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;

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
        var id = mapper.Map<TId>(request.Id!);

        TEntity entity = await entityQueryRepository.GetAsync(id);

        TDetailDto dto = mapper.Map<TDetailDto>(entity);

        return dto;
    }
}