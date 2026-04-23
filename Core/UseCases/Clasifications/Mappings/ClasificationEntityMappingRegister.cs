using Mapster;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Clasifications.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Clasifications.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Clasifications.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Clasifications.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ClasificationAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ClasificationAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Clasifications.Mappings;

internal sealed class ClasificationEntityMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Guid, ClasificationId>()
            .MapWith(src => new ClasificationId(src));

        config.NewConfig<Clasification, ClasificationBasicDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest, src => src);

        config.NewConfig<Clasification, ClasificationDetailDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest, src => src);

        config.NewConfig<ClasificationDetailQuery, ClasificationId>()
            .MapWith(src => new ClasificationId(src.Id));

        config.NewConfig<ClasificationCreateCommand, Clasification>()
            .MapWith(src => new(
                new ClasificationId(Guid.NewGuid()),
                src.Priority,
                src.IsEnabled,
                false,
                src.Name,
                src.Description
            ));

        config.NewConfig<ClasificationUpdateCommand, Clasification>()
            .Map(dest => dest.Id, src => new ClasificationId(src.Id))
            .Map(dest => dest, src => src);
    }
}