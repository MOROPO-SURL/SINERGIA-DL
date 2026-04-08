using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Roles.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Roles.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.RoleAggregate;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Roles.CQRS.Command.Create;

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
