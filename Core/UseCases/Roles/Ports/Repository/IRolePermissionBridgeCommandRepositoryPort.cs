using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PermissionAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PermissionAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.RoleAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.RoleAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Bridges;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Roles.Ports.Repository;

public interface IRolePermissionBridgeCommandRepositoryPort : IBridgeCommandRepositoryPort<RolePermissionBridge, Role, RoleId, Guid, Permission, PermissionId, string>
{
}
