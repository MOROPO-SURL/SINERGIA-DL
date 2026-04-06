using MapsterMapper;
using MediatR;
using MOROPO.GEDET.CAM.Core.UseCases.Roles.CQRS.Command.Update;
using MOROPO.GEDET.CAM.Core.UseCases.Users.DTOs;
using MOROPO.GEDET.CAM.Core.UseCases.Users.Ports.Repository;
using MOROPO.GEDET.CAM.Domain.Aggretates.RoleAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Aggretates.UserAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.UserAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Bridges;
using MOROPO.GEDET.CAM.Domain.Common.Ports.Service;

namespace MOROPO.GEDET.CAM.Core.UseCases.Users.CQRS.Command.Update;

internal sealed class FullUserUpdateCommandHandler : 
    AbstractUpdateCommandHandler<User, UserId, string, FullUserUpdateCommand, UserDetailDto>,
    IRequestHandler<FullUserUpdateCommand, UserDetailDto>
{
    private readonly IDataIntegrityServicePort dataIntegrityService;
    private readonly IUserRoleBridgeCommandRepositoryPort userRoleBridgeCommandRepository;

    public FullUserUpdateCommandHandler(IUserQueryRepositoryPort entityQueryRepository, IUserCommandRepositoryPort entityCommandRepository, IMapper mapper, IDataIntegrityServicePort dataIntegrityService, IUserRoleBridgeCommandRepositoryPort userRoleBridgeCommandRepository)
        : base(entityCommandRepository, entityQueryRepository, mapper)
    {
        this.dataIntegrityService = dataIntegrityService;
        this.userRoleBridgeCommandRepository = userRoleBridgeCommandRepository;
    }

    protected override async Task ApplyManualMappingAsync(FullUserUpdateCommand request, User entity)
    {
        entity.Signature = await dataIntegrityService.GetEntitySignatureAsync(entity);

        List<UserRoleBridge> outgoins = [.. entity.RoleBridges];

        foreach (var item in request.Roles!)
        {
            if (outgoins.Any(bridge => bridge.LinkedId.Value == item))
            {
                outgoins.Remove(outgoins.First(bridge => bridge.LinkedId.Value == item));

                continue;
            }

            var bridge = new UserRoleBridge(entity.Id, new RoleId(item));

            bridge.Signature = await dataIntegrityService.GetEntitySignatureAsync(bridge);

            entity.RoleBridges.Add(await userRoleBridgeCommandRepository.AddAsync(bridge, false));
        }

        foreach (var item in outgoins)
        {
            await userRoleBridgeCommandRepository.DeleteAsync(item, false);
        }
    }
}
