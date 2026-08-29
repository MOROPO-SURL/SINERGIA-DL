using Mapster;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.LocationAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.SocialSupportDemands.Mappings;

internal sealed class LocationMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<LocationId, Guid>().MapWith(src => src.Value);

        config.NewConfig<LocationId, Guid>().MapWith(src => src.Value);
    }
}
