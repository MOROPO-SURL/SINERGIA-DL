using Mapster;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.LocationAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialSupportDemands.Mappings;

internal sealed class LocationMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<LocationId, Guid>().MapWith(src => src.Value);

        config.NewConfig<LocationId, Guid>().MapWith(src => src.Value);
    }
}
