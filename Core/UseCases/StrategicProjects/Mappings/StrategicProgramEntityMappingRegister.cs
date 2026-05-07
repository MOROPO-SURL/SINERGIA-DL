using Mapster;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjects.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjects.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjects.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjects.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjects.Mappings;

internal sealed class StrategicProjectEntityMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Guid, StrategicProjectId>()
            .MapWith(src => new StrategicProjectId(src));

        config.NewConfig<StrategicProject, StrategicProjectBasicDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest, src => src);

        config.NewConfig<StrategicProject, StrategicProjectDetailDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest, src => src);

        config.NewConfig<StrategicProjectDetailQuery, StrategicProjectId>()
            .MapWith(src => new StrategicProjectId(src.Id));

        config.NewConfig<StrategicProjectCreateCommand, StrategicProject>()
            .MapWith(src => new(
                new StrategicProjectId(Guid.NewGuid()),
                new Domain.Aggretates.StrategicProjectKindAggregate.Values.StrategicProjectKindId(src.KindId),
                new Domain.Aggretates.StrategicProgramAggregate.Values.StrategicProgramId(src.ProgramId),
                src.IsEnabled,
                false,
                src.Name,
                src.Priority,
                src.Description,
                null,
                null
            ));

        config.NewConfig<StrategicProjectUpdateCommand, StrategicProject>()
            .Map(dest => dest.Id, src => new StrategicProjectId(src.Id))
            .Map(dest => dest, src => src);
    }
}