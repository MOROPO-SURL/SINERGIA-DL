using Mapster;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PDLModalities.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PDLModalities.CQRS.Command.Remove;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PDLModalities.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PDLModalities.CQRS.Query.Paginate;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Models.View.PDLModalities.Mappings;

internal sealed class PDLModalityMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(int Sheet, int Limit), PDLModalityPaginateQuery>()
            .Map(dest => dest.Page, src => src.Sheet)
            .Map(dest => dest.Limit, src => src.Limit);

        config.NewConfig<Guid, PDLModalityDetailQuery>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<Guid, PDLModalityRemoveCommand>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<PDLModalityDetailDto, Guid>()
            .MapWith(src => src.Id);
    }
}