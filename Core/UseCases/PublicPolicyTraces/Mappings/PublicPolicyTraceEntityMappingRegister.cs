using Mapster;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PublicPolicyTraces.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PublicPolicyTraces.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PublicPolicyTraces.Mappings;

internal sealed class PublicPolicyTraceEntityMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<long, TraceId>()
            .MapWith(src => new TraceId(src));

        config.NewConfig<PublicPolicyTrace, PublicPolicyTraceBasicDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest, src => src);

        config.NewConfig<PublicPolicyTrace, PublicPolicyTraceDetailDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest, src => src);

        config.NewConfig<PublicPolicyTraceDetailQuery, TraceId>()
            .MapWith(src => new TraceId(src.Id));
    }
}