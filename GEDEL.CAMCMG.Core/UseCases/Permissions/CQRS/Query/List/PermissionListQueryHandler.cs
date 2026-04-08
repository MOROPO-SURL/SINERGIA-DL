using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Permissions.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Permissions.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PermissionAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PermissionAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Permissions.CQRS.Query.List;

internal sealed class PermissionListQueryHandler :
    AbstractListQueryHandler<Permission, PermissionId, string, PermissionDetailDto, PermissionListQuery>,
    IRequestHandler<PermissionListQuery, PermissionDetailDto[]>
{
    public PermissionListQueryHandler(IPermissionQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }
}