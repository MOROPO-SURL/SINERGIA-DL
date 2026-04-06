using MapsterMapper;
using MOROPO.GEDET.CAM.Core.UseCases.Roles.DTOs;
using MOROPO.GEDET.CAM.Core.UseCases.Roles.Ports.Repository;
using MOROPO.GEDET.CAM.Domain.Aggretates.PermissionAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Aggretates.RoleAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.RoleAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Bridges;

namespace MOROPO.GEDET.CAM.Core.UseCases.Roles.CQRS.Command.Update;

internal class RoleUpdateCommandHandler : MediatR.IRequestHandler<RoleUpdateCommand, RoleDetailDto>
{
    private readonly IRoleCommandRepositoryPort roleCommandRepository;
    private readonly IRoleQueryRepositoryPort roleQueryRepository;
    private readonly IRolePermissionBridgeCommandRepositoryPort rolePermissionBridgeCommandRepository;
    private readonly IMapper mapper;

    public RoleUpdateCommandHandler(IRoleCommandRepositoryPort roleCommandRepository, IRoleQueryRepositoryPort roleQueryRepository, IRolePermissionBridgeCommandRepositoryPort rolePermissionBridgeCommandRepository, IMapper mapper)
    {
        this.roleCommandRepository = roleCommandRepository;
        this.roleQueryRepository = roleQueryRepository;
        this.rolePermissionBridgeCommandRepository = rolePermissionBridgeCommandRepository;
        this.mapper = mapper;
    }

    public async Task<RoleDetailDto> Handle(RoleUpdateCommand request, CancellationToken cancellationToken)
    {
        Role entity = await roleQueryRepository.GetAsync(new RoleId(request.Id));

        entity = mapper.Map(request, entity);

        await ApplyManualMappingAsync(request, entity);

        await roleCommandRepository.UpdateAsync(entity);

        return mapper.Map<Role,RoleDetailDto>(await roleQueryRepository.GetAsync(entity.Id));
    }

    protected async Task ApplyManualMappingAsync(RoleUpdateCommand request, Role entity)
    {
        List<RolePermissionBridge> outgoins = [.. entity.PermissionBridges];

        foreach (string item in request.Permissions!)
        {
            if (outgoins.Any(bridge => bridge.LinkedId.Value == item))
            {
                outgoins.Remove(outgoins.First(bridge => bridge.LinkedId.Value == item));

                continue;
            }

            var bridge = new RolePermissionBridge(entity.Id, new PermissionId(item));

            entity.PermissionBridges.Add(await rolePermissionBridgeCommandRepository.AddAsync(bridge, false));
        }

        foreach (var item in outgoins)
        {
            await rolePermissionBridgeCommandRepository.DeleteAsync(item, false);
        }
    }
}