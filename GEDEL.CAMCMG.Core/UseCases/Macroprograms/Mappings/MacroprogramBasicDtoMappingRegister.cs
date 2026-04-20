using Mapster;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Macroprograms.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.MacroprogramAggregate;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Macroprograms.Mappings;

internal sealed class MacroprogramBasicDtoMappingRegister: IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Macroprogram, MacroprogramBasicDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest, src => src);
    }
}
