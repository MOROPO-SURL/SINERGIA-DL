using Mapster;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Locations.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Locations.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Location.CQRS.Command;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.API.Models.SocialSupportDemands.Mappings;

public class SocialSupportDemandMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<LocationCreateRequestModel, LocationCreateCommand>()
            .Map(dest => dest.FeatureImageCreateCommand, src => src.FeatureImageCreateRequest.Adapt<ImageCreateCommand>())
            .Map(dest => dest, src => src);

        config.NewConfig<LocationUpdateRequestModel, LocationUpdateCommand>()
            .Map(dest => dest.FeatureImageCreateCommand, src => src.FeatureImageCreateRequest.Adapt<ImageCreateCommand>())
            .Map(dest => dest, src => src);
    }
}