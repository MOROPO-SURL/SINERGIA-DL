using Microsoft.EntityFrameworkCore;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.DevelopmentActorProfiles.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.DevelopmentActorProfileAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.DevelopmentActorProfiles;

internal sealed class LegalOwnedPDLDevelopmentActorProfileQueryRepositoryPortAdapter : AbstractEntityQueryRepositoryPortAdapter<LegalOwnedPDLDevelopmentActorProfile, DevelopmentActorProfileId, Guid>, ILegalOwnedPDLDevelopmentActorProfileQueryRepositoryPort
{
    public LegalOwnedPDLDevelopmentActorProfileQueryRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }

    protected override IQueryable<LegalOwnedPDLDevelopmentActorProfile> GetQueryableDbSet()
    {
        return base.GetQueryableDbSet()
            .AsSplitQuery()
            .Include(entity => entity.Owner).ThenInclude(entity => entity!.Image)
            .Include(entity => entity.Modality)
            .Include(entity => entity.MainEconomicActivity)
            .Include(entity => entity.SecoundaryEconomicActivityBridges).ThenInclude(bridge => bridge.Linked)
            .Include(entity => entity.MainLocation).ThenInclude(entity => entity!.FeatureImage)
            .Include(entity => entity.LocationBridges).ThenInclude(bridge => bridge.Linked).ThenInclude(entity => entity!.FeatureImage)
            .Include(entity => entity.Holder).ThenInclude(entity => entity!.Image);
    }
}