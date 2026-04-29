using Mapster;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate.Entities;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.Mappings;

internal sealed class StrategicProgramEntityMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Guid, StrategicProgramId>()
            .MapWith(src => new StrategicProgramId(src));

        config.NewConfig<StrategicProgram, StrategicProgramBasicDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest, src => src);

        config.NewConfig<StrategicProgram, StrategicProgramDetailDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest, src => src);

        config.NewConfig<StrategicProgramDetailQuery, StrategicProgramId>()
            .MapWith(src => new StrategicProgramId(src.Id));

        config.NewConfig<StrategicProgramCreateCommand, StrategicProgram>()
            .MapWith(src => new(
                new StrategicProgramId(Guid.NewGuid()),
                new Domain.Aggretates.StrategicLineAggregate.Values.StrategicLineId(src.LineId),
                new Domain.Aggretates.StrategicAxeAggregate.Values.StrategicAxeId(src.AxeId),
                src.IsEnabled,
                src.Name,
                false,
                src.Priority,
                new Domain.Aggretates.PersonAggregate.Values.PersonId(src.CoordinatorId),
                new ProgramObjective[] { },
                new ProgramAction[] { },
                new ProgramProjectIdea[] { },
                new ProgramImpact[] { },
                new Domain.Bridges.StrategicProgramOrganizationBridge[] { },
                null,
                src.Description
            ));

        config.NewConfig<StrategicProgramUpdateCommand, StrategicProgram>()
            .Map(dest => dest.Id, src => new StrategicProgramId(src.Id))
            .Map(dest => dest, src => src);
    }
}