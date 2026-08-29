using MapsterMapper;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;

internal abstract class AbstractRemoveCommandHandler<TEntity, TId, TIdValue, TRemoveCommand> : MediatR.IRequestHandler<TRemoveCommand>
    where TEntity : class, IEntity<TId, TIdValue>
    where TId : struct, IId<TIdValue>
    where TRemoveCommand : IRemoveCommand<TIdValue>
{
    private readonly IEntityCommandRepositoryPort<TEntity, TId, TIdValue> entityCommandRepository;
    private readonly IMapper mapper;

    protected AbstractRemoveCommandHandler(IEntityCommandRepositoryPort<TEntity, TId, TIdValue> entityCommandRepository, IMapper mapper)
    {
        this.entityCommandRepository = entityCommandRepository;
        this.mapper = mapper;
    }

    public async Task Handle(TRemoveCommand request, CancellationToken cancellationToken)
    {
        TEntity entity = await entityCommandRepository.GetAsync(mapper.Map<TId>(request.Id!));

        await entityCommandRepository.DeleteAsync(entity);
    }
}
