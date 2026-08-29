using MapsterMapper;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;

internal abstract class AbstractEnableCommandHandler<TEntity, TId, TIdValue, TEnableCommand> : MediatR.IRequestHandler<TEnableCommand>
    where TEntity : class, IEnableableEntity<TId, TIdValue>
    where TId : struct, IId<TIdValue>
    where TEnableCommand : IEnableCommand<TIdValue>
{
    private readonly IEntityCommandRepositoryPort<TEntity, TId, TIdValue> entityCommandRepository;
    private readonly IMapper mapper;

    protected AbstractEnableCommandHandler(IEntityCommandRepositoryPort<TEntity, TId, TIdValue> entityCommandRepository, IMapper mapper)
    {
        this.entityCommandRepository = entityCommandRepository;
        this.mapper = mapper;
    }

    public async Task Handle(TEnableCommand request, CancellationToken cancellationToken)
    {
        TEntity entity = await entityCommandRepository.GetAsync(mapper.Map<TId>(request.Id!));

        entity.IsEnabled = true;

        await entityCommandRepository.UpdateAsync(entity);
    }
}