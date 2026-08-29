using Mapster;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Locations.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Locations.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Location.CQRS.Command;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.API.Models.SocialSupportDemands.Mappings;

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