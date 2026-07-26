using Mapster;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialSupportDemands.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialSupportDemands.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.SocialSupportDemandAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.SocialSupportDemandAggregate.Bridges;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.SocialSupportDemandAggregate.Entities;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.SocialSupportDemandAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialSupportDemands.Mappings;

internal sealed class SocialSupportDemandMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Guid, SocialSupportDemandId>().MapWith(src => new SocialSupportDemandId(src));

        config.NewConfig<SocialSupportDemandId, Guid>().MapWith(src => src.Value);

        config.NewConfig<LocationId, Guid>().MapWith(src => src.Value);

        config.NewConfig<SocialSupportDemand, SocialSupportDemandDetailDto>()
            .Map(dest => dest.Images, src => src.ImageBridges.Select(bridge => bridge.Linked.Adapt<ImageBasicDto>()))
            .Map(dest => dest, src => src);

        config.NewConfig<SocialSupportDemandCreateCommand, SocialSupportDemand>()
            .Map(dest => dest.Locations, src => Array.Empty<Location>())
            .Map(dest => dest.ImageBridges, src => Array.Empty<SocialSupportDemandImageBridge>())
            .Map(dest => dest, src => src);
    }
}
