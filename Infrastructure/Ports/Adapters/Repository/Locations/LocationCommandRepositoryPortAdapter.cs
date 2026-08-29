using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Locations.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.LocationAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.LocationAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.Locations;

internal sealed class LocationCommandRepositoryPortAdapter : AbstractEntityCommandRepositoryPortAdapter<Location, LocationId, Guid>, ILocationCommandRepository
{
    public LocationCommandRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }
}
