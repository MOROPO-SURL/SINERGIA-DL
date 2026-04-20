using Mapster;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.CQRS.Command.Archive;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.CQRS.Command.Disable;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.CQRS.Command.Enable;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.CQRS.Command.Remove;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.CQRS.Command.Unarchive;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.API.Models.Objectives.Mappings;

internal sealed class PrimitiveObjectiveMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(int Sheet, int Limit), ObjectivePaginateQuery>()
            .Map(dest => dest.Page, src => src.Sheet)
            .Map(dest => dest.Limit, src => src.Limit);

        config.NewConfig<ObjectiveDetailDto, Guid>()
            .MapWith(src => src.Id);

        config.NewConfig<Guid, ObjectiveDetailQuery>()
            .MapWith(src => new ObjectiveDetailQuery(src));

        config.NewConfig<Guid, ObjectiveRemoveCommand>()
            .MapWith(src => new ObjectiveRemoveCommand(src));

        config.NewConfig<Guid, ObjectiveEnableCommand>()
            .MapWith(src => new ObjectiveEnableCommand(src));

        config.NewConfig<Guid, ObjectiveDisableCommand>()
            .MapWith(src => new ObjectiveDisableCommand(src));

        config.NewConfig<Guid, ObjectiveArchiveCommand>()
            .MapWith(src => new ObjectiveArchiveCommand(src));

        config.NewConfig<Guid, ObjectiveUnarchiveCommand>()
            .MapWith(src => new ObjectiveUnarchiveCommand(src));
    }
}
