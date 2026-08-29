using Mapster;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.MacroprogramAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Macroprograms.Mappings;

internal sealed class PrimitivesMacroprogramMappingRegister: IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Guid, MacroprogramId>()
            .MapWith(src => new MacroprogramId(src));
    }
}
