using Mapster;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.KeyVariables.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.KeyVariables.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.KeyVariables.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.KeyVariables.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.KeyVariableAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.KeyVariableAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.KeyVariables.Mappings;

internal sealed class KeyVariableEntityMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Guid, KeyVariableId>()
            .MapWith(src => new KeyVariableId(src));

        config.NewConfig<KeyVariable, KeyVariableBasicDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest, src => src);

        config.NewConfig<KeyVariable, KeyVariableDetailDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest, src => src);

        config.NewConfig<KeyVariableDetailQuery, KeyVariableId>()
            .MapWith(src => new KeyVariableId(src.Id));

        config.NewConfig<KeyVariableCreateCommand, KeyVariable>()
            .MapWith(src => new(
                new KeyVariableId(Guid.NewGuid()),
                false,
                src.Priority,
                src.Name,
                src.Alias,
                src.Description
            ));

        config.NewConfig<KeyVariableUpdateCommand, KeyVariable>()
            .Map(dest => dest.Id, src => new KeyVariableId(src.Id))
            .Map(dest => dest, src => src);
    }
}