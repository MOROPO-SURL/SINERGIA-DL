using Mapster;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritoryPotentials.CQRS.Command.Archive;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritoryPotentials.CQRS.Command.Remove;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritoryPotentials.CQRS.Command.Unarchive;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritoryPotentials.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritoryPotentials.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritoryPotentials.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Models.View.TerritoryPotentials.Mappings;

internal sealed class TerritoryPotentialMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(int Sheet, int Limit), TerritoryPotentialPaginateQuery>()
            .Map(dest => dest.Page, src => src.Sheet)
            .Map(dest => dest.Limit, src => src.Limit);

        config.NewConfig<Guid, TerritoryPotentialDetailQuery>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<Guid, TerritoryPotentialRemoveCommand>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<Guid, TerritoryPotentialArchiveCommand>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<Guid, TerritoryPotentialUnarchiveCommand>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<TerritoryPotentialDetailDto, Guid>()
            .MapWith(src => src.Id);
    }
}
