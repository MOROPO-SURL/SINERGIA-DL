using MapsterMapper;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;

internal abstract class AbstractUpdateCommandHandler<TEntity, TId, TIdValue, TUpdateCommand, TDetailDto> : MediatR.IRequestHandler<TUpdateCommand, TDetailDto>
    where TEntity : class, IEntity<TId, TIdValue>
    where TId : struct, IId<TIdValue>
    where TUpdateCommand : IUpdateCommand<TIdValue, TDetailDto>
{
    private readonly IEntityCommandRepositoryPort<TEntity, TId, TIdValue> entityCommandRepository;
    private readonly IEntityQueryRepositoryPort<TEntity, TId, TIdValue> entityQueryRepository;
    private readonly IMapper mapper;

    protected AbstractUpdateCommandHandler(IEntityCommandRepositoryPort<TEntity, TId, TIdValue> entityCommandRepository, IEntityQueryRepositoryPort<TEntity, TId, TIdValue> entityQueryRepository, IMapper mapper)
    {
        this.entityCommandRepository = entityCommandRepository;
        this.entityQueryRepository = entityQueryRepository;
        this.mapper = mapper;
    }

    public async Task<TDetailDto> Handle(TUpdateCommand request, CancellationToken cancellationToken)
    {
        TEntity entity = await entityCommandRepository.GetAsync(mapper.Map<TId>(request.Id!));

        entity = mapper.Map(request, entity);

        Action? postCreateDelegatedAction = await PerformPreUpdateAsync(request, entity);

        await entityCommandRepository.UpdateAsync(entity);

        postCreateDelegatedAction?.Invoke();

        await PerformPostUpdateAsync(request, entity);

        return mapper.Map<TEntity, TDetailDto>(await entityQueryRepository.GetAsync(entity.Id));
    }

    protected virtual Task<Action?> PerformPreUpdateAsync(TUpdateCommand request, TEntity entity) => Task.FromResult<Action?>(null);

    protected virtual Task PerformPostUpdateAsync(TUpdateCommand request, TEntity entity) => Task.CompletedTask;
}