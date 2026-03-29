using MOROPO.GEDET.CAM.Core.UseCases.Roles.Ports.Repository;
using MOROPO.GEDET.CAM.Domain.Aggretates.RoleAggregate.Values;

namespace MOROPO.GEDET.CAM.Core.UseCases.Roles.CQRS.Command.Remove;

internal class RoleRemoveCommandHandler : MediatR.IRequestHandler<RoleRemoveCommand>
{
    private readonly IRoleCommandRepositoryPort roleCommandRepository;
    private readonly IRoleQueryRepositoryPort roleQueryRepository;

    public RoleRemoveCommandHandler(IRoleCommandRepositoryPort roleCommandRepository, IRoleQueryRepositoryPort roleQueryRepository)
    {
        this.roleCommandRepository = roleCommandRepository;
        this.roleQueryRepository = roleQueryRepository;
    }

    public async Task Handle(RoleRemoveCommand request, CancellationToken cancellationToken)
    {
        var entity = await roleQueryRepository.GetAsync(new RoleId(request.Id));

        await roleCommandRepository.DeleteAsync(entity);

        return;
    }
}
