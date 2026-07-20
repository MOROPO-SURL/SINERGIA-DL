using Mapster;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OrganizationKindTraces.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OrganizationKindTraces.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OrganizationKindTraces.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.OrganizationKindTraces.Mappings;

internal sealed class OrganizationKindTraceMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(int Sheet, int Limit), OrganizationKindTracePaginateQuery>()
            .Map(dest => dest.Page, src => src.Sheet)
            .Map(dest => dest.Limit, src => src.Limit);

        config.NewConfig<long, OrganizationKindTraceDetailQuery>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<OrganizationKindTraceDetailDto, long>()
            .MapWith(src => src.Id);
    }
}
