using Mapster;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Macroprograms.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicAxes.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicAxes.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicAxe.CQRS.Command;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.API.Models.StrategicAxes.Mappings;

public class StrategicAxeMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<StrategicAxeCreateRequestModel, StrategicAxeCreateCommand>()
            .Map(dest => dest.Macroprograms, src => src.Macroprograms.Select(item => item.Adapt<MacroprogramBasicDto>()).ToArray())
            .Map(dest => dest, src => src);

        config.NewConfig<StrategicAxeUpdateRequestModel, StrategicAxeUpdateCommand>()
            .Map(dest => dest.InMacroprograms, dest => dest.InMacroprograms.Select(item => item.Adapt<MacroprogramBasicDto>()).ToArray())
            .Map(dest => dest.OutMacroprograms, dest => dest.OutMacroprograms.Select(item => item.Adapt<MacroprogramBasicDto>()).ToArray())
            .Map(dest => dest, src => src);
    }
}