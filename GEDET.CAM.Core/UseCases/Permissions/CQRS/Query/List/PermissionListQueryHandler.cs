using MediatR;
using MOROPO.GEDET.CAM.Core.UseCases.Permissions.Ports.Repository;
using MOROPO.GEDET.CAM.Core.UseCases.Roles.CQRS.Query.List;
using MOROPO.GEDET.CAM.Domain.Aggretates.PermissionAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.PermissionAggregate.Values;

namespace MOROPO.GEDET.CAM.Core.UseCases.Permissions.CQRS.Query.List;

internal sealed class PermissionListQueryHandler : 
    AbstractListQueryHandler<Permission, PermissionId, string, DTOs.PermissionDetailDto, PermissionListQuery>, 
    IRequestHandler<PermissionListQuery, DTOs.PermissionDetailDto[]>
{
    public PermissionListQueryHandler(IPermissionQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }
}