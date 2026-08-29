using Mapster;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.UnitMeasurements.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.UnitMeasurementAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.UnitMeasurementAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.UnitMeasurements.Mappings;

internal sealed class UnitMeasurementCreateCommandMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<UnitMeasurementCreateCommand, UnitMeasurement>()
            .Map(dest => dest.Id, src => new UnitMeasurementId(Guid.NewGuid()))
            .Map(dest => dest.IsArchived, src => false)
            .Map(dest => dest, src => src);
    }
}