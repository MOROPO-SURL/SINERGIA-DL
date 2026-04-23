using Mapster;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Clasifications.CQRS.Command.Archive;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Clasifications.CQRS.Command.Remove;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Clasifications.CQRS.Command.Unarchive;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Clasifications.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Clasifications.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Clasifications.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.API.Models.Clasifications.Mappings;

internal class ClasificationMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(int Sheet, int Limit), ClasificationPaginateQuery>()
            .Map(dest => dest.Page, src => src.Sheet)
            .Map(dest => dest.Limit, src => src.Limit);

        config.NewConfig<ClasificationDetailDto, Guid>()
            .MapWith(src => src.Id);

        config.NewConfig<Guid, ClasificationDetailQuery>()
            .MapWith(src => new ClasificationDetailQuery(src));

        config.NewConfig<Guid, ClasificationRemoveCommand>()
            .MapWith(src => new ClasificationRemoveCommand(src));

        config.NewConfig<Guid, ClasificationArchiveCommand>()
            .MapWith(src => new ClasificationArchiveCommand(src));

        config.NewConfig<Guid, ClasificationUnarchiveCommand>()
            .MapWith(src => new ClasificationUnarchiveCommand(src));
    }
}