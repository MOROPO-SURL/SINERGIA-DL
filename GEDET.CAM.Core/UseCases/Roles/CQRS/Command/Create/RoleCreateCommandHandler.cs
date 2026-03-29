using MapsterMapper;
using MediatR;
using MOROPO.GEDET.CAM.Core.UseCases.Roles.DTOs;
using MOROPO.GEDET.CAM.Core.UseCases.Roles.Ports.Repository;
using MOROPO.GEDET.CAM.Domain.Aggretates.RoleAggregate;

namespace MOROPO.GEDET.CAM.Core.UseCases.Roles.CQRS.Command.Create;

internal class RoleCreateCommandHandler : IRequestHandler<RoleCreateCommand, RoleDetailDto>
{
    private readonly IRoleCommandRepositoryPort roleCommandRepository;
    private readonly IMapper mapper;

    public RoleCreateCommandHandler(IRoleCommandRepositoryPort roleCommandRepository, IMapper mapper)
    {
        this.roleCommandRepository = roleCommandRepository;
        this.mapper = mapper;
    }

    public async Task<RoleDetailDto> Handle(RoleCreateCommand command, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<RoleCreateCommand, Role>(command);

        await roleCommandRepository.AddAsync(entity);

        return mapper.Map<Role, RoleDetailDto>(entity);
    }
}
