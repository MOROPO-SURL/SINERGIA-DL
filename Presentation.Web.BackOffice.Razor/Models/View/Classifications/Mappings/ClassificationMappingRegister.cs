using Mapster;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Classifications.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Classifications.CQRS.Command.Archive;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Classifications.CQRS.Command.Disable;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Classifications.CQRS.Command.Enable;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Classifications.CQRS.Command.Remove;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Classifications.CQRS.Command.Unarchive;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Classifications.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Classifications.CQRS.Query.Paginate;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.Classifications.Mappings;

internal sealed class ClassificationMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(int Sheet, int Limit), ClassificationPaginateQuery>()
            .Map(dest => dest.Page, src => src.Sheet)
            .Map(dest => dest.Limit, src => src.Limit);

        config.NewConfig<Guid, ClassificationDetailQuery>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<Guid, ClassificationRemoveCommand>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<Guid, ClassificationArchiveCommand>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<Guid, ClassificationUnarchiveCommand>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<Guid, ClassificationEnableCommand>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<Guid, ClassificationDisableCommand>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<ClassificationDetailDto, Guid>()
            .MapWith(src => src.Id);
    }
}