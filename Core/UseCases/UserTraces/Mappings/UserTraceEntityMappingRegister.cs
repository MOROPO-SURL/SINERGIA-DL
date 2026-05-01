using Mapster;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Users.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Users.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.UserTraces.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.UserTraces.Mappings;

internal sealed class UserTraceEntityMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<long, TraceId>()
            .MapWith(src => new TraceId(src));

        config.NewConfig<UserTrace, UserTraceBasicDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest, src => src);

        config.NewConfig<UserTrace, UserTraceDetailDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest, src => src);

        config.NewConfig<UserTraceDetailQuery, TraceId>()
            .MapWith(src => new TraceId(src.Id));
    }
}