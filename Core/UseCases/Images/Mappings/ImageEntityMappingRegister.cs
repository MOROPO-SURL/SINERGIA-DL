using Mapster;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ImageAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ImageAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Images.Mappings;

internal sealed class ImageEntityMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<ImageId, Guid>()
            .MapWith(src => src.Value);

        config.NewConfig<Image, ImageBasicDto>()
            .Map(dest => dest.Extension, src => MimeTypes.MimeTypeMap.GetExtension(src.ContentType))
            .Map(dest => dest, src => src);
    }
}
