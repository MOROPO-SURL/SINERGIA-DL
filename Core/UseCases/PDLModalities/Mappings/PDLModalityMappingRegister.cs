using Mapster;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PDLModalities.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PDLModalityAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PDLModalityAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PDLModalities.Mappings;

internal sealed class PDLModalityEntityMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<PDLModalityId, Guid>()
            .MapWith(src => src.Value);

        config.NewConfig<Guid, PDLModalityId>()
            .MapWith(src => new PDLModalityId(src));

        config.NewConfig<PDLModalityCreateCommand, PDLModality>()
            .Map(dest => dest.Id, src => new PDLModalityId(Guid.NewGuid()))
            .Map(dest => dest, src => src);
    }
}