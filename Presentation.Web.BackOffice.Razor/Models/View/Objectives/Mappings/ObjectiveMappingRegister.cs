using Mapster;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.CQRS.Command.Archive;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.CQRS.Command.Disable;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.CQRS.Command.Enable;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.CQRS.Command.Remove;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.CQRS.Command.Unarchive;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.Objectives.Mappings;

internal sealed class ObjectiveMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(int Sheet, int Limit), ObjectivePaginateQuery>()
            .Map(dest => dest.Page, src => src.Sheet)
            .Map(dest => dest.Limit, src => src.Limit);

        config.NewConfig<Guid, ObjectiveDetailQuery>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<Guid, ObjectiveRemoveCommand>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<Guid, ObjectiveArchiveCommand>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<Guid, ObjectiveUnarchiveCommand>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<Guid, ObjectiveEnableCommand>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<Guid, ObjectiveDisableCommand>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<ObjectiveDetailDto, Guid>()
            .MapWith(src => src.Id);
    }
}