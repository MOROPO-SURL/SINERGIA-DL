using MapsterMapper;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;

internal abstract class AbstractUnarchiveCommandHandler<TEntity, TId, TIdValue, TUnarchiveCommand> : MediatR.IRequestHandler<TUnarchiveCommand>
    where TEntity : class, IArchivableEntity<TId, TIdValue>
    where TId : struct, IId<TIdValue>
    where TUnarchiveCommand : IUnarchiveCommand<TIdValue>
{
    private readonly IEntityCommandRepositoryPort<TEntity, TId, TIdValue> entityCommandRepository;
    private readonly IMapper mapper;

    protected AbstractUnarchiveCommandHandler(IEntityCommandRepositoryPort<TEntity, TId, TIdValue> entityCommandRepository, IMapper mapper)
    {
        this.entityCommandRepository = entityCommandRepository;
        this.mapper = mapper;
    }

    public async Task Handle(TUnarchiveCommand request, CancellationToken cancellationToken)
    {
        TEntity entity = await entityCommandRepository.GetAsync(mapper.Map<TId>(request.Id!));

        entity.IsArchived = false;

        await entityCommandRepository.UpdateAsync(entity);
    }
}
