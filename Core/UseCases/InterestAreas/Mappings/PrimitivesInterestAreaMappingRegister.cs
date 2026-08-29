using Mapster;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.InterestAreaAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.InterestAreas.Mappings;

internal sealed class PrimitivesInterestAreaMappingRegister: IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Guid, InterestAreaId>()
            .MapWith(src => new InterestAreaId(src));
    }
}
