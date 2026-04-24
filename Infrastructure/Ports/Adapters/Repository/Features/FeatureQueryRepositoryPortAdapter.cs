using Microsoft.EntityFrameworkCore;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Features.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.FeatureAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.FeatureAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.Features;

internal sealed class FeatureQueryRepositoryPortAdapter :
    AbstractEntityQueryRepositoryPortAdapter<Feature, FeatureId, Guid>,
    IFeatureQueryRepositoryPort
{
    public FeatureQueryRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }

    protected override IQueryable<Feature> GetQueryableDbSet()
    {
        return base.GetQueryableDbSet().Include(entity => entity.Kind);
    }
}