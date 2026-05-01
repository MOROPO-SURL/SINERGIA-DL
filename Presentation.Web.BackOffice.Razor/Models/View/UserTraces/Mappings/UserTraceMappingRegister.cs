using Mapster;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Users.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Users.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Users.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.UserTraces.Mappings;

internal sealed class UserTraceMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(int Sheet, int Limit), UserTracePaginateQuery>()
            .Map(dest => dest.Page, src => src.Sheet)
            .Map(dest => dest.Limit, src => src.Limit);

        config.NewConfig<long, UserTraceDetailQuery>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<UserTraceDetailDto, long>()
            .MapWith(src => src.Id);
    }
}