using Mapster;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.UnitMeasurementAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.UnitMeasurements.Mappings;

internal sealed class PrimitivesUnitMeasurementMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Guid, UnitMeasurementId>()
            .MapWith(src => new UnitMeasurementId(src));
    }
}
