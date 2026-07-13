using Mapster;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.EconomicActivities.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.EconomicActivityAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.EconomicActivityAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.EconomicActivities.Mappings;

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
