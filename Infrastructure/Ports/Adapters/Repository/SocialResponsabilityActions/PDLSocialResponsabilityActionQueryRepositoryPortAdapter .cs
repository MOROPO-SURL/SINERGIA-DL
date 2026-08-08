using Microsoft.EntityFrameworkCore;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialResponsabilityActions.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.SocialResponsabilityActionAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.SocialResponsabilityActionAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.SocialResponsabilityActions;

internal sealed class PDLSocialResponsabilityActionQueryRepositoryPortAdapter : AbstractEntityQueryRepositoryPortAdapter<PDLSocialResponsabilityAction, SocialResponsabilityActionId, Guid>, IPDLSocialResponsabilityActionQueryRepositoryPort
{
    public PDLSocialResponsabilityActionQueryRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }

    protected override IQueryable<PDLSocialResponsabilityAction> GetQueryableDbSet()
    {
        return base.GetQueryableDbSet()
            .AsSplitQuery()
            .Include(entity => entity.Owner).ThenInclude(entity => entity!.Owner).ThenInclude(entity => entity!.Image)
            .Include(entity => entity.LocationBridges).ThenInclude(bridge => bridge.Linked).ThenInclude(entity => entity!.FeatureImage)
            .Include(entity => entity.ImageBridges).ThenInclude(bridge => bridge.Linked);
    }
}