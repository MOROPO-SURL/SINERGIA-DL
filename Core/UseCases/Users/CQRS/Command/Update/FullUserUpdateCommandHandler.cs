using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Ports.Service;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Users.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Users.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.RoleAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.UserAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.UserAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Bridges;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Users.CQRS.Command.Update;

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

    protected override async Task<object?> PerformPreUpdateAsync(FullUserUpdateCommand request, User entity)
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

        return null;
    }
}
