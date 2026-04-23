using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OrganizationKinds.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationKindAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationKindAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.OrganizationKinds;

internal sealed class OrganizationKindQueryRepositoryPortAdapter :
    AbstractEntityQueryRepositoryPortAdapter<OrganizationKind, OrganizationKindId, Guid>,
    IOrganizationKindQueryRepositoryPort
{
    public OrganizationKindQueryRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }
}