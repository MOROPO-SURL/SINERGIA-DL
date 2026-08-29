using Microsoft.EntityFrameworkCore;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.SocialSupportDemands.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.SocialSupportDemandAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.SocialSupportDemandAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.SocialSupportDemands;

internal sealed class SocialSupportDemandQueryRepositoryPortAdapter : AbstractEntityQueryRepositoryPortAdapter<SocialSupportDemand, SocialSupportDemandId, Guid>, ISocialSupportDemandQueryRepositoryPort
{
    public SocialSupportDemandQueryRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }

    protected override IQueryable<SocialSupportDemand> GetQueryableDbSet()
    {
        return base.GetQueryableDbSet()
            .AsSplitQuery()
            .Include(entity => entity.LocationBridges).ThenInclude(bridge => bridge.Linked).ThenInclude(entity => entity!.FeatureImage)
            .Include(entity => entity.ImageBridges).ThenInclude(bridge => bridge.Linked);
    }
}
