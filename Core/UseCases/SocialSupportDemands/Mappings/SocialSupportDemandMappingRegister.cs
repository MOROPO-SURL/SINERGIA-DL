using Mapster;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Locations.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.SocialSupportDemands.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.SocialSupportDemands.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.SocialSupportDemandAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.SocialSupportDemandAggregate.Bridges;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.SocialSupportDemandAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.SocialSupportDemands.Mappings;

internal sealed class SocialSupportDemandMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Guid, SocialSupportDemandId>().MapWith(src => new SocialSupportDemandId(src));

        config.NewConfig<Guid?, SocialSupportDemandId?>().MapWith(src => src == null ? null : new SocialSupportDemandId(src.Value));

        config.NewConfig<SocialSupportDemandId, Guid>().MapWith(src => src.Value);

        config.NewConfig<SocialSupportDemandId?, Guid?>().MapWith(src => src == null ? null : src.Value.Value);

        config.NewConfig<SocialSupportDemand, SocialSupportDemandDetailDto>()
            .Map(dest => dest.Images, src => src.ImageBridges.Select(bridge => bridge.Linked.Adapt<ImageBasicDto>()))
            .Map(dest => dest.Locations, src => src.LocationBridges.Select(bridge => bridge.Linked.Adapt<LocationDetailDto>()))
            .Map(dest => dest, src => src);

        config.NewConfig<SocialSupportDemandCreateCommand, SocialSupportDemand>()
            .Map(dest => dest.LocationBridges, src => Array.Empty<SocialSupportDemandLocationBridge>())
            .Map(dest => dest.ImageBridges, src => Array.Empty<SocialSupportDemandImageBridge>())
            .Map(dest => dest, src => src);
    }
}
