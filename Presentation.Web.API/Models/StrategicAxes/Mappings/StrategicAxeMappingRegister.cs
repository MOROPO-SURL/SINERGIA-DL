using Mapster;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Macroprograms.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicAxes.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicAxes.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicAxe.CQRS.Command;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.API.Models.StrategicAxes.Mappings;

public class StrategicAxeMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<StrategicAxeCreateRequestModel, StrategicAxeCreateCommand>()
            .Map(dest => dest.Id, src => Guid.NewGuid())
            .Map(dest => dest.Macroprograms, src => src.Macroprograms.Select(item => item.Adapt<MacroprogramBasicDto>()).ToArray())
            .Map(dest => dest, src => src);

        config.NewConfig<StrategicAxeUpdateRequestModel, StrategicAxeUpdateCommand>()
            .Map(dest => dest.InMacroprograms, dest => dest.InMacroprograms.Select(item => item.Adapt<MacroprogramBasicDto>()).ToArray())
            .Map(dest => dest.OutMacroprograms, dest => dest.OutMacroprograms.Select(item => item.Adapt<MacroprogramBasicDto>()).ToArray())
            .Map(dest => dest, src => src);
    }
}