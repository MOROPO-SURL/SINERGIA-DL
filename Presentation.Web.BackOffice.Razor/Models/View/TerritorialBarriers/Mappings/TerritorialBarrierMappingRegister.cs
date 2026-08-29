using Mapster;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritorialBarriers.CQRS.Command.Archive;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritorialBarriers.CQRS.Command.Remove;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritorialBarriers.CQRS.Command.Unarchive;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritorialBarriers.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritorialBarriers.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritorialBarriers.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Models.View.TerritorialBarriers.Mappings;

internal sealed class TerritorialBarrierMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(int Sheet, int Limit), TerritorialBarrierPaginateQuery>()
            .Map(dest => dest.Page, src => src.Sheet)
            .Map(dest => dest.Limit, src => src.Limit);

        config.NewConfig<Guid, TerritorialBarrierDetailQuery>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<Guid, TerritorialBarrierRemoveCommand>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<Guid, TerritorialBarrierArchiveCommand>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<Guid, TerritorialBarrierUnarchiveCommand>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<TerritorialBarrierDetailDto, Guid>()
            .MapWith(src => src.Id);
    }
}
