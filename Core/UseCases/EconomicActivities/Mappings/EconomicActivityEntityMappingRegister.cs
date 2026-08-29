using Mapster;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.EconomicActivities.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.EconomicActivityAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.EconomicActivityAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.EconomicActivities.Mappings;

internal sealed class EconomicActivityEntityMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<EconomicActivityId, int>()
            .MapWith(src => src.Value);

        config.NewConfig<int, EconomicActivityId>()
            .MapWith(src => new EconomicActivityId(src));

        config.NewConfig<EconomicActivityCreateCommand, EconomicActivity>()
            .Map(dest => dest.IsArchived, src => false);
    }
}
