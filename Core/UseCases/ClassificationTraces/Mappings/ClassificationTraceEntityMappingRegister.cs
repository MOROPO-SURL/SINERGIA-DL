using Mapster;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Classifications.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Classifications.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.ClassificationTraces.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.ClassificationTraces.Mappings;

internal sealed class ClassificationTraceEntityMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<long, TraceId>()
            .MapWith(src => new TraceId(src));

        config.NewConfig<ClassificationTrace, ClassificationTraceBasicDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest, src => src);

        config.NewConfig<ClassificationTrace, ClassificationTraceDetailDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest, src => src);

        config.NewConfig<ClassificationTraceDetailQuery, TraceId>()
            .MapWith(src => new TraceId(src.Id));
    }
}