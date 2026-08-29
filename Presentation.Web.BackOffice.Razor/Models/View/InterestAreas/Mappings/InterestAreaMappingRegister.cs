using Mapster;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.InterestAreas.CQRS.Command.Archive;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.InterestAreas.CQRS.Command.Disable;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.InterestAreas.CQRS.Command.Enable;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.InterestAreas.CQRS.Command.Remove;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.InterestAreas.CQRS.Command.Unarchive;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.InterestAreas.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.InterestAreas.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.InterestAreas.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Models.View.InterestAreas.Mappings;

internal sealed class InterestAreaMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(int Sheet, int Limit), InterestAreaPaginateQuery>()
            .Map(dest => dest.Page, src => src.Sheet)
            .Map(dest => dest.Limit, src => src.Limit);

        config.NewConfig<Guid, InterestAreaDetailQuery>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<Guid, InterestAreaRemoveCommand>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<Guid, InterestAreaArchiveCommand>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<Guid, InterestAreaUnarchiveCommand>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<Guid, InterestAreaEnableCommand>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<Guid, InterestAreaDisableCommand>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<InterestAreaDetailDto, Guid>()
            .MapWith(src => src.Id);
    }
}