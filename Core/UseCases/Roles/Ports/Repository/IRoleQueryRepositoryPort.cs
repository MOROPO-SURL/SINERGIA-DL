using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.RoleAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.RoleAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Roles.Ports.Repository;

public interface IRoleQueryRepositoryPort : IEntityQueryRepositoryPort<Role, RoleId, Guid>
{
}