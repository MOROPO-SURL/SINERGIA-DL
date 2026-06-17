using Mapster;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicAxes.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicAxes.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicAxes.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicAxes.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxeAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxeAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicAxes.Mappings;

internal sealed class StrategicAxeEntityMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<int, StrategicAxeId>()
            .MapWith(src => new StrategicAxeId(src));

        config.NewConfig<StrategicAxe, StrategicAxeBasicDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest, src => src);

        config.NewConfig<StrategicAxe, StrategicAxeDetailDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest, src => src);

        config.NewConfig<StrategicAxeDetailQuery, StrategicAxeId>()
            .MapWith(src => new StrategicAxeId(src.Id));

        config.NewConfig<StrategicAxeCreateCommand, StrategicAxe>()
            .MapWith(src => new(
                new StrategicAxeId(src.Id),
                false,
                src.Name,
                src.IsEnabled,
                null,
                src.CoordinatorId == null ? null : new Domain.Aggretates.PersonAggregate.Values.PersonId(src.CoordinatorId.Value),
                src.Description
            ));

        config.NewConfig<StrategicAxeUpdateCommand, StrategicAxe>()
            .Map(dest => dest.Id, src => new StrategicAxeId(src.Id))
            .Map(dest => dest, src => src);
    }
}