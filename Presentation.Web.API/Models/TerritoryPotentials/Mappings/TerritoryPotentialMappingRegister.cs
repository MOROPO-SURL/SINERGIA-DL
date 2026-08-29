using Mapster;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritoryPotentials.CQRS.Command.Archive;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritoryPotentials.CQRS.Command.Remove;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritoryPotentials.CQRS.Command.Unarchive;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritoryPotentials.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritoryPotentials.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritoryPotentials.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.API.Models.TerritoryPotentials.Mappings;

internal class TerritoryPotentialMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(int Sheet, int Limit), TerritoryPotentialPaginateQuery>()
            .Map(dest => dest.Page, src => src.Sheet)
            .Map(dest => dest.Limit, src => src.Limit);

        config.NewConfig<TerritoryPotentialDetailDto, Guid>()
            .MapWith(src => src.Id);

        config.NewConfig<Guid, TerritoryPotentialDetailQuery>()
            .MapWith(src => new TerritoryPotentialDetailQuery(src));

        config.NewConfig<Guid, TerritoryPotentialRemoveCommand>()
            .MapWith(src => new TerritoryPotentialRemoveCommand(src));

        config.NewConfig<Guid, TerritoryPotentialArchiveCommand>()
            .MapWith(src => new TerritoryPotentialArchiveCommand(src));

        config.NewConfig<Guid, TerritoryPotentialUnarchiveCommand>()
            .MapWith(src => new TerritoryPotentialUnarchiveCommand(src));
    }
}