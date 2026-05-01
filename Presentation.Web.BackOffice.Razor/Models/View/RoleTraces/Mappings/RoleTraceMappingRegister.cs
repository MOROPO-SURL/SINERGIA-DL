using Mapster;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Roles.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Roles.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Roles.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.RoleTraces.Mappings;

internal sealed class RoleTraceMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(int Sheet, int Limit), RoleTracePaginateQuery>()
            .Map(dest => dest.Page, src => src.Sheet)
            .Map(dest => dest.Limit, src => src.Limit);

        config.NewConfig<long, RoleTraceDetailQuery>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<RoleTraceDetailDto, long>()
            .MapWith(src => src.Id);
    }
}