using Mapster;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Classifications.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Classifications.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Classifications.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Classifications.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ClassificationAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ClassificationAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Classifications.Mappings;

internal sealed class ClassificationEntityMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Guid, ClassificationId>()
            .MapWith(src => new ClassificationId(src));

        config.NewConfig<Classification, ClassificationBasicDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest, src => src);

        config.NewConfig<Classification, ClassificationDetailDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest, src => src);

        config.NewConfig<ClassificationDetailQuery, ClassificationId>()
            .MapWith(src => new ClassificationId(src.Id));

        config.NewConfig<ClassificationCreateCommand, Classification>()
            .MapWith(src => new(
                new ClassificationId(Guid.NewGuid()),
                src.Priority,
                src.IsEnabled,
                false,
                src.Name,
                src.Description
            ));

        config.NewConfig<ClassificationUpdateCommand, Classification>()
            .Map(dest => dest.Id, src => new ClassificationId(src.Id))
            .Map(dest => dest, src => src);
    }
}