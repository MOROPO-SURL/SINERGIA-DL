using Mapster;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.InterestAreas.CQRS.Command.Archive;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.InterestAreas.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.InterestAreas.CQRS.Command.Disable;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.InterestAreas.CQRS.Command.Enable;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.InterestAreas.CQRS.Command.Remove;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.InterestAreas.CQRS.Command.Unarchive;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.InterestAreas.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.InterestAreas.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.InterestAreas.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.UnitMeasurements.CQRS.Command.Archive;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.UnitMeasurements.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.UnitMeasurements.CQRS.Command.Disable;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.UnitMeasurements.CQRS.Command.Enable;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.UnitMeasurements.CQRS.Command.Remove;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.UnitMeasurements.CQRS.Command.Unarchive;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.UnitMeasurements.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.UnitMeasurements.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.UnitMeasurements.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.InterestArea.CQRS.Command;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.UnitMeasurement.CQRS.Command;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.API.Models.InterestAreas.Mappings
{
    internal class InterestAreaMappingRegister: IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(int Sheet, int Limit), InterestAreaPaginateQuery>()
                .Map(dest => dest.Page, src => src.Sheet)
                .Map(dest => dest.Limit, src => src.Limit);

            config.NewConfig<InterestAreaDetailDto, Guid>()
                .MapWith(src => src.Id);

            config.NewConfig<Guid, InterestAreaDetailQuery>()
                .MapWith(src => new InterestAreaDetailQuery(src));

            config.NewConfig<Guid, InterestAreaRemoveCommand>()
                .MapWith(src => new InterestAreaRemoveCommand(src));

            config.NewConfig<Guid, InterestAreaEnableCommand>()
            .MapWith(src => new InterestAreaEnableCommand(src));

            config.NewConfig<Guid, InterestAreaDisableCommand>()
                .MapWith(src => new InterestAreaDisableCommand(src));

            config.NewConfig<Guid, InterestAreaArchiveCommand>()
                .MapWith(src => new InterestAreaArchiveCommand(src));

            config.NewConfig<Guid, InterestAreaUnarchiveCommand>()
                .MapWith(src => new InterestAreaUnarchiveCommand(src));

            config.NewConfig<InterestAreaCreateRequestModel, InterestAreaCreateCommand>()
                .Map(dest => dest.Id, src => Guid.NewGuid())
                .Map(dest => dest, src => src);
        }
    }
}
