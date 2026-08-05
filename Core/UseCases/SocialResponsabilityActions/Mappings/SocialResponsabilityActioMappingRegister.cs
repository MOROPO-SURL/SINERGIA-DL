using Mapster;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Locations.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialResponsabilityActions.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialResponsabilityActions.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.SocialResponsabilityActionAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.SocialResponsabilityActionAggregate.Bridges;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.SocialResponsabilityActionAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialResponsabilityActions.Mappings;

internal sealed class SocialResponsabilityActionMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<SocialResponsabilityActionId, Guid>().MapWith(src => src.Value);

        config.NewConfig<Guid, SocialResponsabilityActionId>().MapWith(src => new SocialResponsabilityActionId(src));

        config.NewConfig<SRLSocialResponsabilityAction, SRLSocialResponsabilityActionDetailDto>()
            .Map(dest => dest.Images, src => src.ImageBridges.Select(bridge => bridge.Linked.Adapt<ImageBasicDto>()))
            .Map(dest => dest.Locations, src => src.LocationBridges.Select(bridge => bridge.Linked.Adapt<LocationDetailDto>()))
            .Map(dest => dest, src => src);

        config.NewConfig<SRLSocialResponsabilityActionCreateCommand, SRLSocialResponsabilityAction>()
            .Map(dest => dest.Id, src => new SocialResponsabilityActionId(Guid.NewGuid()))
            .Map(dest => dest.IsArchived, src => false)
            .Map(dest => dest.LocationBridges, src => Array.Empty<SocialResponsabilityActionLocationBridge>())
            .Map(dest => dest.ImageBridges, src => Array.Empty<SocialResponsabilityActionImageBridge>())
            .Map(dest => dest, src => src);

        config.NewConfig<PDLSocialResponsabilityAction, PDLSocialResponsabilityActionDetailDto>()
            .Map(dest => dest.Images, src => src.ImageBridges.Select(bridge => bridge.Linked.Adapt<ImageBasicDto>()))
            .Map(dest => dest.Locations, src => src.LocationBridges.Select(bridge => bridge.Linked.Adapt<LocationDetailDto>()))
            .Map(dest => dest, src => src);

        config.NewConfig<PDLSocialResponsabilityActionCreateCommand, PDLSocialResponsabilityAction>()
            .Map(dest => dest.Id, src => new SocialResponsabilityActionId(Guid.NewGuid()))
            .Map(dest => dest.IsArchived, src => false)
            .Map(dest => dest.LocationBridges, src => Array.Empty<SocialResponsabilityActionLocationBridge>())
            .Map(dest => dest.ImageBridges, src => Array.Empty<SocialResponsabilityActionImageBridge>())
            .Map(dest => dest, src => src);
    }
}
