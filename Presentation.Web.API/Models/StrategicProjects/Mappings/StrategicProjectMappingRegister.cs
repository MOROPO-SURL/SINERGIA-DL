using Mapster;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Macroprograms.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjects.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjects.CQRS.Command.Create.Clipped;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjects.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProject.CQRS.Command;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.API.Models.StrategicProjects.Mappings
{
    public class StrategicProjectMappingRegister : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<StrategicProjectCreateRequestModel, StrategicProjectCreateCommand>()
                .Map(dest => dest.Id, src => Guid.NewGuid())
                .Map(dest => dest.SpecificObjectives, src => src.SpecificObjectives.Select(item => item.Adapt<SpecificObjectiveProjectClippedCreateCommand>()).ToArray())
                .Map(dest => dest.Indicators, src => src.Indicators.Select(item => item.Adapt<IndicatorClippedCreateCommand>()).ToArray())
                .Map(dest => dest.Macroprograms, src => src.Macroprograms.Select(item => item.Adapt<MacroprogramBasicDto>()).ToArray())
                .Map(dest => dest, src => src);

            config.NewConfig<StrategicProjectUpdateRequestModel, StrategicProjectUpdateCommand>()
                .Map(dest => dest.InMacroprograms, src => src.InMacroprograms.Select(item => item.Adapt<MacroprogramBasicDto>()).ToArray())
                .Map(dest => dest.OutMacroprograms, src => src.OutMacroprograms.Select(item => item.Adapt<MacroprogramBasicDto>()).ToArray())
                .Map(dest => dest, src => src);
        }
    }
}
