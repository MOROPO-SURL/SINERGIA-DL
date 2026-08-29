using Mapster;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Roles.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Roles.Ports.Repository;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Roles.CQRS.Query.List;

internal class AbstractListQueryHandler : IRequestHandler<RoleListQuery, RoleBasicDto[]>
{
    private readonly IRoleQueryRepositoryPort roleQueryRepository;

    public AbstractListQueryHandler(IRoleQueryRepositoryPort roleQueryRepository)
    {
        this.roleQueryRepository = roleQueryRepository;
    }

    public Task<RoleBasicDto[]> Handle(RoleListQuery request, CancellationToken cancellationToken)
    {
        if (request.Criteria != null)
        {
            return Task.FromResult(roleQueryRepository.GetFindByQueryable(request.Criteria).ProjectToType<RoleBasicDto>().ToArray());
        }

        return Task.FromResult(roleQueryRepository.GetAllQueryable().ProjectToType<RoleBasicDto>().ToArray());
    }
}
