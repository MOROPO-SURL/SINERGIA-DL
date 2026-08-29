using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Roles.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Roles.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.RoleAggregate;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Roles.CQRS.Command.Create;

internal class RoleCreateCommandHandler : IRequestHandler<RoleCreateCommand, RoleDetailDto>
{
    private readonly IRoleCommandRepositoryPort entityCommandRepository;
    private readonly IRoleQueryRepositoryPort entityQueryRepository;
    private readonly IMapper mapper;

    public RoleCreateCommandHandler(IRoleCommandRepositoryPort roleCommandRepository, IRoleQueryRepositoryPort roleQueryRepository, IMapper mapper)
    {
        entityCommandRepository = roleCommandRepository;
        entityQueryRepository = roleQueryRepository;
        this.mapper = mapper;
    }

    public async Task<RoleDetailDto> Handle(RoleCreateCommand request, CancellationToken cancellationToken)
    {
        Role entity = mapper.Map<RoleCreateCommand, Role>(request);

        entity.PermissionBridges = [.. request.Permissions.Select(item => new Domain.Bridges.RolePermissionBridge(entity.Id, new Domain.Aggretates.PermissionAggregate.Values.PermissionId(item)))];

        await entityCommandRepository.AddAsync(entity);

        return mapper.Map<Role, RoleDetailDto>(await entityQueryRepository.GetAsync(entity.Id));
    }
}
