using MapsterMapper;
using MOROPO.GEDET.CAM.Core.UseCases.Roles.DTOs;
using MOROPO.GEDET.CAM.Core.UseCases.Roles.Ports.Repository;
using MOROPO.GEDET.CAM.Domain.Aggretates.RoleAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.RoleAggregate.Values;

namespace MOROPO.GEDET.CAM.Core.UseCases.Roles.CQRS.Command.Update;

internal class RoleUpdateCommandHandler : MediatR.IRequestHandler<RoleUpdateCommand, RoleDetailDto>
{
    private readonly IRoleCommandRepositoryPort roleCommandRepository;
    private readonly IRoleQueryRepositoryPort roleQueryRepository;
    private readonly IMapper mapper;

    public RoleUpdateCommandHandler(IRoleCommandRepositoryPort roleCommandRepository, IRoleQueryRepositoryPort roleQueryRepository, IMapper mapper)
    {
        this.roleCommandRepository = roleCommandRepository;
        this.roleQueryRepository = roleQueryRepository;
        this.mapper = mapper;
    }

    public async Task<RoleDetailDto> Handle(RoleUpdateCommand command, CancellationToken cancellationToken)
    {
        var entity = await roleQueryRepository.GetAsync(new RoleId(command.Id));

        entity = mapper.Map(command, entity);

        return mapper.Map<Role,RoleDetailDto>(await roleCommandRepository.UpdateAsync(entity));
    }
}