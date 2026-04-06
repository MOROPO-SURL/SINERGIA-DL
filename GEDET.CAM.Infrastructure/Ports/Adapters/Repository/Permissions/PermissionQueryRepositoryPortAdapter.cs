using MOROPO.GEDET.CAM.Core.UseCases.Permissions.Ports.Repository;
using MOROPO.GEDET.CAM.Domain.Aggretates.PermissionAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.PermissionAggregate.Values;
using MOROPO.GEDET.CAM.Infrastructure.Persistence.EF;
using MOROPO.GEDET.CAM.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.GEDET.CAM.Infrastructure.Ports.Adapters.Repository.Permissions;

internal class PermissionQueryRepositoryPortAdapter : AbstractEntityQueryRepositoryPortAdapter<Permission, PermissionId, string>, IPermissionQueryRepositoryPort
{
    public PermissionQueryRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }
}
