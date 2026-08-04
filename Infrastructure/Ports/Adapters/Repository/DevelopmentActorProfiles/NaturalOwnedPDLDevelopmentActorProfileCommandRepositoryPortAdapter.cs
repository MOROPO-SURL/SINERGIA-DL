using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.DevelopmentActorProfiles.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.DevelopmentActorProfiles;

internal sealed class NaturalOwnedPDLDevelopmentActorProfileCommandRepositoryPortAdapter : AbstractEntityCommandRepositoryPortAdapter<NaturalOwnedPDLDevelopmentActorProfile, DevelopmentActorProfileId, Guid>, INaturalOwnedPDLDevelopmentActorProfileCommandRepositoryPort
{
    public NaturalOwnedPDLDevelopmentActorProfileCommandRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }
}
