using Mapster;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.UnitMeasurements.CQRS.Command.Archive;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.UnitMeasurements.CQRS.Command.Disable;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.UnitMeasurements.CQRS.Command.Enable;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.UnitMeasurements.CQRS.Command.Remove;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.UnitMeasurements.CQRS.Command.Unarchive;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.UnitMeasurements.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.UnitMeasurements.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.UnitMeasurements.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.UnitMeasurements.Mappings;

internal sealed class UnitMeasurementMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(int Sheet, int Limit), UnitMeasurementPaginateQuery>()
            .Map(dest => dest.Page, src => src.Sheet)
            .Map(dest => dest.Limit, src => src.Limit);

        config.NewConfig<Guid, UnitMeasurementDetailQuery>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<Guid, UnitMeasurementRemoveCommand>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<Guid, UnitMeasurementArchiveCommand>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<Guid, UnitMeasurementUnarchiveCommand>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<Guid, UnitMeasurementEnableCommand>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<Guid, UnitMeasurementDisableCommand>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<UnitMeasurementDetailDto, Guid>()
            .MapWith(src => src.Id);
    }
}
