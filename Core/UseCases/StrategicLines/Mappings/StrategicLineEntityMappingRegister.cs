using Mapster;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicAxes.DTOs;
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
        config.NewConfig<Guid, StrategicLineId>()
            .MapWith(src => new StrategicLineId(src));

        config.NewConfig<StrategicLine, StrategicLineBasicDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.Axe, src => src.Axe == null ? null : src.Axe.Adapt<StrategicAxeBasicDto>())
            .Map(dest => dest, src => src);

        config.NewConfig<StrategicLine, StrategicLineDetailDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.Axe, src => src.Axe == null ? null : src.Axe.Adapt<StrategicAxeBasicDto>())
            .Map(dest => dest, src => src);

        config.NewConfig<StrategicLineDetailQuery, StrategicLineId>()
            .MapWith(src => new StrategicLineId(src.Id));

        config.NewConfig<StrategicLineCreateCommand, StrategicLine>()
            .MapWith(src => new(
                new StrategicLineId(src.Id),
                src.Index,
                src.IsEnabled,
                src.Name,
                false,
                new Domain.Aggretates.PersonAggregate.Values.PersonId(src.CoordinatorId),
                src.Objective,
                Array.Empty<Domain.Aggretates.StrategicLineAggregate.Entities.StrategicLineAction>(),
                Array.Empty<Domain.Aggretates.StrategicLineAggregate.Bridges.StrategicLineOrganizationBridge>(),
                src.AxeId == null ? null : new StrategicAxeId(src.AxeId.Value),
                null,
                null,
                src.Description
            ));

        config.NewConfig<StrategicLineUpdateCommand, StrategicLine>()
            .Map(dest => dest.Id, src => new StrategicLineId(src.Id))
            .Map(dest => dest.AxeId, src => GetStrategicAxeId(src))
            .Map(dest => dest.CoordinatorId, src => new Domain.Aggretates.PersonAggregate.Values.PersonId(src.CoordinatorId))
            .Map(dest => dest, src => src);
    }

    private static StrategicAxeId? GetStrategicAxeId(StrategicLineUpdateCommand src)
    {
        return src.AxeId == null ? null : new StrategicAxeId(src.AxeId.Value);
    }
}