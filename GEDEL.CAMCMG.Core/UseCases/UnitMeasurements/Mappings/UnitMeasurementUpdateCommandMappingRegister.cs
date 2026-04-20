using Mapster;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.UnitMeasurements.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.UnitMeasurementAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.UnitMeasurementAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.UnitMeasurements.Mappings;

internal class UnitMeasurementUpdateCommandMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<UnitMeasurementUpdateCommand, UnitMeasurement>()
            .Map(dest => dest.Id, src => new UnitMeasurementId(src.Id))
            .Map(dest => dest, src => src);
    }
}
