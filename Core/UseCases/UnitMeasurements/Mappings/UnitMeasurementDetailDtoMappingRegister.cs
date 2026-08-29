using Mapster;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.UnitMeasurements.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.UnitMeasurementAggregate;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.UnitMeasurements.Mappings;

internal sealed class UnitMeasurementDetailDtoMappingRegister: IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<UnitMeasurement, UnitMeasurementDetailDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest, src => src);
    }
}
