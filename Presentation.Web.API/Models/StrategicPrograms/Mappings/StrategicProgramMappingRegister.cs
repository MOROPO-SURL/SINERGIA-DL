using Mapster;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Macroprograms.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Organizations.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicPrograms.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicPrograms.CQRS.Command.Create.Clipped;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicPrograms.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProgram.CQRS.Command;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.API.Models.StrategicPrograms.Mappings;

public class StrategicProgramMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<StrategicProgramCreateRequestModel, StrategicProgramCreateCommand>()
            .Map(dest => dest.Id, src => Guid.NewGuid())
            .Map(dest => dest.SpecificObjectives, src => src.SpecificObjectives.Select(item => item.Adapt<SpecificObjectiveClippedCreateCommand>()).ToArray())
            .Map(dest => dest.Impacts, src => src.Impacts.Select(item => item.Adapt<ImpactClippedCreateCommand>()).ToArray())
            .Map(dest => dest.Actions, src => src.Actions.Select(item => item.Adapt<ActionClippedCreateCommand>()).ToArray())
            .Map(dest => dest.Organizations, src => src.Organizations.Select(item => item.Adapt<OrganizationBasicDto>()).ToArray())
            .Map(dest => dest.Macroprograms, src => src.Macroprograms.Select(item => item.Adapt<MacroprogramBasicDto>()).ToArray())
            .Map(dest => dest, src => src);

        config.NewConfig<StrategicProgramUpdateRequestModel, StrategicProgramUpdateCommand>()
            .Map(dest => dest.InOrganizations, src => src.InOrganizations.Select(item => item.Adapt<OrganizationBasicDto>()).ToArray())
            .Map(dest => dest.OutOrganizations, src => src.OutOrganizations.Select(item => item.Adapt<OrganizationBasicDto>()).ToArray())
            .Map(dest => dest.InMacroprograms, src => src.InMacroprograms.Select(item => item.Adapt<MacroprogramBasicDto>()).ToArray())
            .Map(dest => dest.OutMacroprograms, src => src.OutMacroprograms.Select(item => item.Adapt<MacroprogramBasicDto>()).ToArray())
            .Map(dest => dest, src => src);

        //config.NewConfig<ActionCreateClippedRequestModel, ActionClippedCreateCommand>()
        //    .Map(dest => dest.Indicators, src => src.Indicators.Select(item => item.Adapt<ActionIndicatorClippedCreateCommand>()).ToArray())
        //    .Map(dest => dest, src => src);

        //config.NewConfig<ActionUpdateClippedRequestModel, ActionClippedUpdateCommand>
    }
}
