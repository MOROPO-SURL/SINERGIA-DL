using Mapster;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Macroprograms.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.MacroprogramAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Macroprograms.Mappings;

internal sealed class MacroprogramDetailQueryMappingRegister: IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<MacroprogramDetailQuery, MacroprogramId>()
            .MapWith(src => new MacroprogramId(src.Id));
    }
}
