using Mapster;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.FeatureKinds.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.FeatureKinds.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.FeatureKinds.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.FeatureKinds.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.FeatureKindAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.FeatureKindAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.FeatureKinds.Mappings;

internal sealed class FeatureKindEntityMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Guid, FeatureKindId>()
            .MapWith(src => new FeatureKindId(src));

        config.NewConfig<FeatureKind, FeatureKindBasicDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest, src => src);

        config.NewConfig<FeatureKind, FeatureKindDetailDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest, src => src);

        config.NewConfig<FeatureKindDetailQuery, FeatureKindId>()
            .MapWith(src => new FeatureKindId(src.Id));

        config.NewConfig<FeatureKindCreateCommand, FeatureKind>()
            .MapWith(src => new(
                new FeatureKindId(Guid.NewGuid()),
                src.IsEnabled,
                src.Priority,
                src.Name,
                src.Description
            ));

        config.NewConfig<FeatureKindUpdateCommand, FeatureKind>()
            .Map(dest => dest.Id, src => new FeatureKindId(src.Id))
            .Map(dest => dest, src => src);
    }
}
