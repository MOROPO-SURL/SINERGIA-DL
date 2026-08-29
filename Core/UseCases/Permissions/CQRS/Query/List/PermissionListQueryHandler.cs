using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Permissions.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Permissions.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PermissionAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PermissionAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Permissions.CQRS.Query.List;

internal sealed class PermissionListQueryHandler :
    AbstractListQueryHandler<Permission, PermissionId, string, PermissionDetailDto, PermissionListQuery>,
    IRequestHandler<PermissionListQuery, PermissionDetailDto[]>
{
    public PermissionListQueryHandler(IPermissionQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }
}