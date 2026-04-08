using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;

internal abstract class AbstractCreateCommandHandler<TEntity, TId, TIdValue, TCreateCommand, TDetailDto> : IRequestHandler<TCreateCommand, TDetailDto>
    where TEntity : class, IEntity<TId, TIdValue>
    where TId : struct, IId<TIdValue>
    where TCreateCommand : ICreateCommand<TDetailDto>
    where TDetailDto : IDetailDto
{
    private readonly IEntityCommandRepositoryPort<TEntity, TId, TIdValue> entityCommandRepository;
    private readonly IEntityQueryRepositoryPort<TEntity, TId, TIdValue> entityQueryRepository;
    private readonly IMapper mapper;

    protected AbstractCreateCommandHandler(IEntityCommandRepositoryPort<TEntity, TId, TIdValue> entityCommandRepository, IEntityQueryRepositoryPort<TEntity, TId, TIdValue> entityQueryRepository, IMapper mapper)
    {
        this.entityCommandRepository = entityCommandRepository;
        this.entityQueryRepository = entityQueryRepository;
        this.mapper = mapper;
    }

    public async Task<TDetailDto> Handle(TCreateCommand request, CancellationToken cancellationToken)
    {
        TEntity entity = mapper.Map<TCreateCommand, TEntity>(request);

        await ApplyManualMappingAsync(request, entity);

        await entityCommandRepository.AddAsync(entity);

        return mapper.Map<TEntity, TDetailDto>(await entityQueryRepository.GetAsync(entity.Id));
    }

    protected virtual Task ApplyManualMappingAsync(TCreateCommand request, TEntity entity) => Task.CompletedTask;
}
