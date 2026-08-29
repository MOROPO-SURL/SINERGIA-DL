using Mapster;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjects.CQRS.Command.Archive;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjects.CQRS.Command.Disable;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjects.CQRS.Command.Enable;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjects.CQRS.Command.Remove;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjects.CQRS.Command.Unarchive;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjects.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjects.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjects.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Models.View.StrategicProjects.Mappings;

internal sealed class StrategicProjectMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(int Sheet, int Limit), StrategicProjectPaginateQuery>()
            .Map(dest => dest.Page, src => src.Sheet)
            .Map(dest => dest.Limit, src => src.Limit);

        config.NewConfig<Guid, StrategicProjectDetailQuery>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<Guid, StrategicProjectRemoveCommand>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<Guid, StrategicProjectArchiveCommand>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<Guid, StrategicProjectUnarchiveCommand>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<Guid, StrategicProjectEnableCommand>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<Guid, StrategicProjectDisableCommand>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<StrategicProjectDetailDto, Guid>()
            .MapWith(src => src.Id);
    }
}