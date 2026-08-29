using Mapster;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectIdeaTraces.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectIdeaTraces.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectIdeaTraces.Mappings;

internal sealed class StrategicProjectIdeaTraceEntityMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<long, TraceId>()
            .MapWith(src => new TraceId(src));

        config.NewConfig<StrategicProjectIdeaTrace, StrategicProjectIdeaTraceBasicDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest, src => src);

        config.NewConfig<StrategicProjectIdeaTrace, StrategicProjectIdeaTraceDetailDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest, src => src);

        config.NewConfig<StrategicProjectIdeaTraceDetailQuery, TraceId>()
            .MapWith(src => new TraceId(src.Id));
    }
}