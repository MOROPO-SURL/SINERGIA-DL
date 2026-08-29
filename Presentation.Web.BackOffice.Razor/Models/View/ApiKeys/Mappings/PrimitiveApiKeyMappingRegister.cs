using Mapster;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.ApiKeys.CQRS.Command.Remove;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.ApiKeys.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.ApiKeys.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.ApiKeys.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Models.View.ApiKeys.Mappings;

internal sealed class PrimitiveApiKeyMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(int Sheet, int Limit), ApiKeyPaginateQuery>()
            .Map(dest => dest.Page, src => src.Sheet)
            .Map(dest => dest.Limit, src => src.Limit);

        config.NewConfig<Guid, ApiKeyDetailQuery>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<Guid, ApiKeyRemoveCommand>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<ApiKeyDetailDto, Guid>()
            .MapWith(src => src.Id);
    }
}
