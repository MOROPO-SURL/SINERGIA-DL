using Mapster;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectKinds.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectKinds.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectKinds.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectKinds.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProjectKindAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProjectKindAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectKinds.Mappings;

internal sealed class StrategicProjectKindEntityMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Guid, StrategicProjectKindId>()
            .MapWith(src => new StrategicProjectKindId(src));

        config.NewConfig<StrategicProjectKind, StrategicProjectKindBasicDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest, src => src);

        config.NewConfig<StrategicProjectKind, StrategicProjectKindDetailDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest, src => src);

        config.NewConfig<StrategicProjectKindDetailQuery, StrategicProjectKindId>()
            .MapWith(src => new StrategicProjectKindId(src.Id));

        config.NewConfig<StrategicProjectKindCreateCommand, StrategicProjectKind>()
            .MapWith(src => new(
                new StrategicProjectKindId(Guid.NewGuid()),
                src.IsEnabled,
                false,
                src.Priority,
                src.Name,
                src.Description
            ));

        config.NewConfig<StrategicProjectKindUpdateCommand, StrategicProjectKind>()
            .Map(dest => dest.Id, src => new StrategicProjectKindId(src.Id))
            .Map(dest => dest, src => src);
    }
}