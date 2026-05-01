using Mapster;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Roles.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Roles.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.RoleTraces.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.RoleTraces.Mappings;

internal sealed class RoleTraceEntityMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<long, TraceId>()
            .MapWith(src => new TraceId(src));

        config.NewConfig<RoleTrace, RoleTraceBasicDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest, src => src);

        config.NewConfig<RoleTrace, RoleTraceDetailDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest, src => src);

        config.NewConfig<RoleTraceDetailQuery, TraceId>()
            .MapWith(src => new TraceId(src.Id));
    }
}