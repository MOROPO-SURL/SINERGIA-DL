using Mapster;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritorialBarriers.CQRS.Command.Archive;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritorialBarriers.CQRS.Command.Remove;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritorialBarriers.CQRS.Command.Unarchive;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritorialBarriers.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritorialBarriers.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritorialBarriers.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.API.Models.TerritorialBarriers.Mappings;

internal class TerritorialBarrierMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(int Sheet, int Limit), TerritorialBarrierPaginateQuery>()
            .Map(dest => dest.Page, src => src.Sheet)
            .Map(dest => dest.Limit, src => src.Limit);

        config.NewConfig<TerritorialBarrierDetailDto, Guid>()
            .MapWith(src => src.Id);

        config.NewConfig<Guid, TerritorialBarrierDetailQuery>()
            .MapWith(src => new TerritorialBarrierDetailQuery(src));

        config.NewConfig<Guid, TerritorialBarrierRemoveCommand>()
            .MapWith(src => new TerritorialBarrierRemoveCommand(src));

        config.NewConfig<Guid, TerritorialBarrierArchiveCommand>()
            .MapWith(src => new TerritorialBarrierArchiveCommand(src));

        config.NewConfig<Guid, TerritorialBarrierUnarchiveCommand>()
            .MapWith(src => new TerritorialBarrierUnarchiveCommand(src));
    }
}