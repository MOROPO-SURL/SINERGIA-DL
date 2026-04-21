using Mapster;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.InterestAreaAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.InterestAreas.Mappings;

internal sealed class PrimitivesInterestAreaMappingRegister: IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Guid, InterestAreaId>()
            .MapWith(src => new InterestAreaId(src));
    }
}
