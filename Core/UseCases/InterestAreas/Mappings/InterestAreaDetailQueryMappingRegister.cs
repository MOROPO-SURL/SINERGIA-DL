using Mapster;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.InterestAreas.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.InterestAreaAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.InterestAreas.Mappings;

internal sealed class InterestAreaDetailQueryMappingRegister: IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<InterestAreaDetailQuery, InterestAreaId>()
            .MapWith(src => new InterestAreaId(src.Id));
    }
}
