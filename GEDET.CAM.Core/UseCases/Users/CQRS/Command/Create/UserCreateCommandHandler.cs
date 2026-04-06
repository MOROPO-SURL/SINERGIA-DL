using MapsterMapper;
using MediatR;
using MOROPO.GEDET.CAM.Core.UseCases.Roles.CQRS.Command.Create;
using MOROPO.GEDET.CAM.Core.UseCases.Users.DTOs;
using MOROPO.GEDET.CAM.Core.UseCases.Users.Ports.Repository;
using MOROPO.GEDET.CAM.Domain.Aggretates.UserAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.UserAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Common.Ports.Service;

namespace MOROPO.GEDET.CAM.Core.UseCases.Users.CQRS.Command.Create;

internal sealed class UserCreateCommandHandler :
    AbstractCreateCommandHandler<User, UserId, string, UserCreateCommand, UserDetailDto>,
    IRequestHandler<UserCreateCommand, UserDetailDto>
{
    private readonly IDataIntegrityServicePort dataIntegrityService;

    public UserCreateCommandHandler(IUserCommandRepositoryPort entityCommandRepository, IUserQueryRepositoryPort entityQueryRepository, IMapper mapper, IDataIntegrityServicePort dataIntegrityService)
        : base(entityCommandRepository, entityQueryRepository, mapper)
    {
        this.dataIntegrityService = dataIntegrityService;
    }

    protected override async Task ApplyManualMappingAsync(UserCreateCommand request, User entity)
    {
        entity.Signature = await dataIntegrityService.GetEntitySignatureAsync(entity);

        foreach (var item in request.Roles!)
        {
            var bridge = new Domain.Bridges.UserRoleBridge(entity.Id, new Domain.Aggretates.RoleAggregate.Values.RoleId(item));

            bridge.Signature = await dataIntegrityService.GetEntitySignatureAsync(bridge);

            entity.RoleBridges.Add(bridge);
        }
    }
}
