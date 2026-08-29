using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.DevelopmentActorProfiles.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.DevelopmentActorProfileAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.DevelopmentActorProfiles;

internal sealed class LegalOwnedPDLDevelopmentActorProfileCommandRepositoryPortAdapter : AbstractEntityCommandRepositoryPortAdapter<LegalOwnedPDLDevelopmentActorProfile, DevelopmentActorProfileId, Guid>, ILegalOwnedPDLDevelopmentActorProfileCommandRepositoryPort
{
    public LegalOwnedPDLDevelopmentActorProfileCommandRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }
}
