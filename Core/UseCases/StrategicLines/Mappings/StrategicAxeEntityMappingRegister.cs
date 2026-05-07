using Mapster;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxeAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicLineAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicLineAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.Mappings;

internal sealed class StrategicLineEntityMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<int, StrategicLineId>()
            .MapWith(src => new StrategicLineId(src));

        config.NewConfig<StrategicLine, StrategicLineBasicDto>()
            .Map(dest => dest.Id, src => src.FirstId.Value)
            .Map(dest => dest, src => src);

        config.NewConfig<StrategicLine, StrategicLineDetailDto>()
            .Map(dest => dest.Id, src => src.FirstId.Value)
            .Map(dest => dest, src => src);

        config.NewConfig<StrategicLineDetailQuery, StrategicLineId>()
            .MapWith(src => new StrategicLineId(src.Id));

        config.NewConfig<StrategicLineCreateCommand, StrategicLine>()
            .MapWith(src => new(
                new StrategicLineId(src.Id),
                new StrategicAxeId(src.AxeId),
                src.IsEnabled,
                src.Name,
                false,
                new Domain.Aggretates.PersonAggregate.Values.PersonId(src.CoordinatorId),
                new Domain.Aggretates.StrategicLineAggregate.Entities.StrategicLineAction[] { },
                new Domain.Aggretates.StrategicLineAggregate.Bridges.StrategicLineOrganizationBridge[] { },
                null,
                src.Description,
                null
            ));

        config.NewConfig<StrategicLineUpdateCommand, StrategicLine>()
            .Map(dest => dest.FirstId, src => new StrategicLineId(src.Id))
            .Map(dest => dest, src => src);
    }
}