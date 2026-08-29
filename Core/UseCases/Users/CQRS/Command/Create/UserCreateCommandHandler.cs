using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Ports.Service;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Users.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Users.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.RoleAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.UserAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.UserAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Users.CQRS.Command.Create;

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

    protected override async Task PerformPreCreateAsync(UserCreateCommand request, User entity)
    {
        entity.Signature = await dataIntegrityService.GetEntitySignatureAsync(entity);

        foreach (var item in request.Roles!)
        {
            var bridge = new Domain.Bridges.UserRoleBridge(entity.Id, new RoleId(item));

            bridge.Signature = await dataIntegrityService.GetEntitySignatureAsync(bridge);

            entity.RoleBridges.Add(bridge);
        }
    }
}
