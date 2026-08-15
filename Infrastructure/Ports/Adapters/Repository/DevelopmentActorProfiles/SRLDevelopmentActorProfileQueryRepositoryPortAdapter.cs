using Microsoft.EntityFrameworkCore;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.DevelopmentActorProfiles.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.DevelopmentActorProfiles;

internal sealed class SRLDevelopmentActorProfileQueryRepositoryPortAdapter : AbstractEntityQueryRepositoryPortAdapter<SRLDevelopmentActorProfile, DevelopmentActorProfileId, Guid>, ISRLDevelopmentActorProfileQueryRepositoryPort
{
    public SRLDevelopmentActorProfileQueryRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }

    protected override IQueryable<SRLDevelopmentActorProfile> GetQueryableDbSet()
    {
        return base.GetQueryableDbSet()
            .AsSplitQuery()
            .Include(entity => entity.Owner).ThenInclude(entity => entity!.Image)
            .Include(entity => entity.MainEconomicActivity)
            .Include(entity => entity.SecoundaryEconomicActivityBridges).ThenInclude(bridge => bridge.Linked)
            .Include(entity => entity.MainLocation).ThenInclude(entity => entity!.FeatureImage)
            .Include(entity => entity.LocationBridges).ThenInclude(bridge => bridge.Linked).ThenInclude(entity => entity!.FeatureImage)
            .Include(entity => entity.OrganizationBridges).ThenInclude(bridge => bridge.Linked).ThenInclude(entity => entity!.Image)
            .Include(entity => entity.PersonBridges).ThenInclude(bridge => bridge.Linked).ThenInclude(entity => entity!.Image);
    }
}
