using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.OrganizationKinds.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OrganizationKindAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OrganizationKindAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.OrganizationKinds;

internal sealed class OrganizationKindCommandRepositoryPortAdapter :
    AbstractEntityCommandRepositoryPortAdapter<OrganizationKind, OrganizationKindId, Guid>,
    IOrganizationKindCommandRepositoryPort
{
    public OrganizationKindCommandRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }
}