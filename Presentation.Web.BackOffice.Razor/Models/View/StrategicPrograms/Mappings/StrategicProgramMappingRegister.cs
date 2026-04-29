using Mapster;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.CQRS.Command.Archive;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.CQRS.Command.Disable;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.CQRS.Command.Enable;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.CQRS.Command.Remove;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.CQRS.Command.Unarchive;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.StrategicPrograms.Mappings;

internal sealed class StrategicProgramMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(int Sheet, int Limit), StrategicProgramPaginateQuery>()
            .Map(dest => dest.Page, src => src.Sheet)
            .Map(dest => dest.Limit, src => src.Limit);

        config.NewConfig<Guid, StrategicProgramDetailQuery>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<Guid, StrategicProgramRemoveCommand>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<Guid, StrategicProgramArchiveCommand>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<Guid, StrategicProgramUnarchiveCommand>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<Guid, StrategicProgramEnableCommand>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<Guid, StrategicProgramDisableCommand>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<StrategicProgramDetailDto, Guid>()
            .MapWith(src => src.Id);
    }
}