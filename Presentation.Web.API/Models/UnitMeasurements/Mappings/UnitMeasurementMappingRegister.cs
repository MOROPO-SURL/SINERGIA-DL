using Mapster;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Persons.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.UnitMeasurements.CQRS.Command.Archive;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.UnitMeasurements.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.UnitMeasurements.CQRS.Command.Disable;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.UnitMeasurements.CQRS.Command.Enable;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.UnitMeasurements.CQRS.Command.Remove;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.UnitMeasurements.CQRS.Command.Unarchive;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.UnitMeasurements.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.UnitMeasurements.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.UnitMeasurements.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Person.CQRS.Command;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.UnitMeasurement.CQRS.Command;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.API.Models.UnitMeasurements.Mappings;

internal class UnitMeasurementMappingRegister: IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(int Sheet, int Limit), UnitMeasurementPaginateQuery>()
            .Map(dest => dest.Page, src => src.Sheet)
            .Map(dest => dest.Limit, src => src.Limit);

        config.NewConfig<UnitMeasurementDetailDto, Guid>()
            .MapWith(src => src.Id);

        config.NewConfig<Guid, UnitMeasurementDetailQuery>()
            .MapWith(src => new UnitMeasurementDetailQuery(src));

        config.NewConfig<Guid, UnitMeasurementRemoveCommand>()
            .MapWith(src => new UnitMeasurementRemoveCommand(src));

        config.NewConfig<Guid, UnitMeasurementEnableCommand>()
            .MapWith(src => new UnitMeasurementEnableCommand(src));

        config.NewConfig<Guid, UnitMeasurementDisableCommand>()
            .MapWith(src => new UnitMeasurementDisableCommand(src));

        config.NewConfig<Guid, UnitMeasurementArchiveCommand>()
            .MapWith(src => new UnitMeasurementArchiveCommand(src));

        config.NewConfig<Guid, UnitMeasurementUnarchiveCommand>()
            .MapWith(src => new UnitMeasurementUnarchiveCommand(src));

        config.NewConfig<UnitMeasurementCreateRequestModel, UnitMeasurementCreateCommand>()
            .Map(dest => dest.IsEnabled, src => true)
            .Map(dest => dest, src => src);
    }
}
