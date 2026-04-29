using Mapster;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicAxes.CQRS.Command.Archive;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicAxes.CQRS.Command.Disable;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicAxes.CQRS.Command.Enable;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicAxes.CQRS.Command.Remove;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicAxes.CQRS.Command.Unarchive;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicAxes.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicAxes.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicAxes.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.StrategicAxes.Mappings;

internal sealed class StrategicAxeMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(int Sheet, int Limit), StrategicAxePaginateQuery>()
            .Map(dest => dest.Page, src => src.Sheet)
            .Map(dest => dest.Limit, src => src.Limit);

        config.NewConfig<int, StrategicAxeDetailQuery>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<int, StrategicAxeRemoveCommand>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<int, StrategicAxeArchiveCommand>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<int, StrategicAxeUnarchiveCommand>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<int, StrategicAxeEnableCommand>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<int, StrategicAxeDisableCommand>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<StrategicAxeDetailDto, int>()
            .MapWith(src => src.Id);
    }
}