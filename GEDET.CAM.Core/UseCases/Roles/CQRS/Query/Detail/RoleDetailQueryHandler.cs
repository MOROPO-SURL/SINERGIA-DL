using MapsterMapper;
using MediatR;
using MOROPO.GEDET.CAM.Core.UseCases.Roles.DTOs;
using MOROPO.GEDET.CAM.Core.UseCases.Roles.Ports.Repository;
using MOROPO.GEDET.CAM.Domain.Aggretates.RoleAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.RoleAggregate.Values;

namespace MOROPO.GEDET.CAM.Core.UseCases.Roles.CQRS.Query.Detail;

internal sealed class RoleDetailQueryHandler : IRequestHandler<RoleDetailQuery, RoleDetailDto>
{
    private readonly IRoleQueryRepositoryPort roleQueryRepository;
    private readonly IMapper mapper;

    public RoleDetailQueryHandler(IRoleQueryRepositoryPort roleQueryRepository, IMapper mapper)
    {
        this.roleQueryRepository = roleQueryRepository;
        this.mapper = mapper;
    }

    public async Task<RoleDetailDto> Handle(RoleDetailQuery request, CancellationToken cancellationToken)
    {
        Role entity = await roleQueryRepository.GetAsync(new RoleId(request.Id));

        return mapper.Map<RoleDetailDto>(entity);
    }
}
