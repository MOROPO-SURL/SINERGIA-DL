using Mapster;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Macroprograms.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Persons.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicAxes.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicAxes.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicAxes.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicAxes.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.MacroprogramAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicAxeAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicAxeAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicLineAggregate.Bridges;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicAxes.Mappings;

internal sealed class StrategicAxeEntityMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<int, StrategicAxeId>().MapWith(src => new StrategicAxeId(src));

        config.NewConfig<StrategicAxeId, int>().MapWith(src => src.Value);

        config.NewConfig<StrategicAxe, StrategicAxeBasicDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest, src => src);

        config.NewConfig<StrategicAxe, StrategicAxeDetailDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.Coordinator, src => src.Coordinator == null ? null : src.Coordinator.Adapt<PersonBasicDto>())
            .Map(dest => dest.Macroprograms, src => src.MacroprogramBridges.OrderBy(bridge => bridge.Linked!.Index).Select(bridge => bridge.Linked.Adapt<MacroprogramBasicDto>()).ToArray())
            .Map(dest => dest, src => src);

        config.NewConfig<StrategicAxeDetailQuery, StrategicAxeId>().MapWith(src => new StrategicAxeId(src.Id));

        config.NewConfig<StrategicAxeCreateCommand, StrategicAxe>().MapWith(src => new(
                new StrategicAxeId(src.Id),
                false,
                src.Name,
                src.IsEnabled,
                src.Macroprograms.Select(item => new StrategicAxeMacroprogramBridge(new StrategicAxeId(src.Id), new MacroprogramId(item.Id), null)).ToArray(),
                null,
                src.CoordinatorId == null ? null : new Domain.Aggretates.PersonAggregate.Values.PersonId(src.CoordinatorId.Value),
                src.Description
            ));

        config.NewConfig<StrategicAxeUpdateCommand, StrategicAxe>()
            .Map(dest => dest.Id, src => new StrategicAxeId(src.Id))
            .Map(dest => dest, src => src)
            .AfterMapping((src, dest) =>
            {
                #region Macroprograms

                foreach (var item in src.InMacroprograms)
                {
                    dest.LinkMacroprogramById(new MacroprogramId(item.Id));
                }

                foreach (var item in src.OutMacroprograms)
                {
                    dest.UnlinkMacroprogramById(new MacroprogramId(item.Id));
                }

                #endregion
            });
    }
}