using Mapster;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicLineTraces.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicLineTraces.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicLineTraces.Mappings;

internal sealed class StrategicLineTraceEntityMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<long, TraceId>()
            .MapWith(src => new TraceId(src));

        config.NewConfig<StrategicLineTrace, StrategicLineTraceBasicDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest, src => src);

        config.NewConfig<StrategicLineTrace, StrategicLineTraceDetailDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest, src => src);

        config.NewConfig<StrategicLineTraceDetailQuery, TraceId>()
            .MapWith(src => new TraceId(src.Id));
    }
}
