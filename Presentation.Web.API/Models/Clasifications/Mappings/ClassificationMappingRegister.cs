using Mapster;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Classifications.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Classifications.CQRS.Command.Archive;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Classifications.CQRS.Command.Remove;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Classifications.CQRS.Command.Unarchive;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Classifications.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Classifications.CQRS.Query.Paginate;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.API.Models.Clasifications.Mappings;

internal class ClassificationMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(int Sheet, int Limit), ClassificationPaginateQuery>()
            .Map(dest => dest.Page, src => src.Sheet)
            .Map(dest => dest.Limit, src => src.Limit);

        config.NewConfig<ClassificationDetailDto, Guid>()
            .MapWith(src => src.Id);

        config.NewConfig<Guid, ClassificationDetailQuery>()
            .MapWith(src => new ClassificationDetailQuery(src));

        config.NewConfig<Guid, ClassificationRemoveCommand>()
            .MapWith(src => new ClassificationRemoveCommand(src));

        config.NewConfig<Guid, ClassificationArchiveCommand>()
            .MapWith(src => new ClassificationArchiveCommand(src));

        config.NewConfig<Guid, ClassificationUnarchiveCommand>()
            .MapWith(src => new ClassificationUnarchiveCommand(src));
    }
}