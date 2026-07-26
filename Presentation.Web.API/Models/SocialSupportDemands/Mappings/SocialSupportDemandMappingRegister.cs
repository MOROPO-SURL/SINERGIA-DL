using Mapster;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialSupportDemands.CQRS.Command.Create.Clipped;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.CQRS.Command.Update.Clipped;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.SocialSupportDemand.CQRS.Command.Clipped;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.API.Models.SocialSupportDemands.Mappings;

public class SocialSupportDemandMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<LocationCreateClippedRequestModel, LocationClippedCreateCommand>()
            .Map(dest => dest.FeatureImageCreateCommand, src => src.FeatureImageCreateRequest.Adapt<ImageCreateCommand>())
            .Map(dest => dest, src => src);

        config.NewConfig<LocationUpdateClippedRequestModel, LocationClippedUpdateCommand>()
            .Map(dest => dest.FeatureImageCreateCommand, src => src.FeatureImageCreateRequest.Adapt<ImageCreateCommand>())
            .Map(dest => dest, src => src);
    }
}