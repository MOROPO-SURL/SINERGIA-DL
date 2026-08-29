using Mapster;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritorialBarriers.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritorialBarriers.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritorialBarriers.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritorialBarriers.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TerritorialBarrierAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TerritorialBarrierAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritorialBarriers.Mappings;

internal sealed class TerritorialBarrierEntityMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Guid, TerritorialBarrierId>()
            .MapWith(src => new TerritorialBarrierId(src));

        config.NewConfig<TerritorialBarrier, TerritorialBarrierBasicDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest, src => src);

        config.NewConfig<TerritorialBarrier, TerritorialBarrierDetailDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest, src => src);

        config.NewConfig<TerritorialBarrierDetailQuery, TerritorialBarrierId>()
            .MapWith(src => new TerritorialBarrierId(src.Id));

        config.NewConfig<TerritorialBarrierCreateCommand, TerritorialBarrier>()
            .MapWith(src => new(
                new TerritorialBarrierId(Guid.NewGuid()),
                false,
                src.Title,
                src.Description
            ));

        config.NewConfig<TerritorialBarrierUpdateCommand, TerritorialBarrier>()
            .Map(dest => dest.Id, src => new TerritorialBarrierId(src.Id))
            .Map(dest => dest, src => src);
    }
}
