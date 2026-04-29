using Mapster;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Macroprograms.CQRS.Command.Archive;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Macroprograms.CQRS.Command.Remove;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Macroprograms.CQRS.Command.Unarchive;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Macroprograms.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Macroprograms.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Macroprograms.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.Macroprograms.Mappings;

internal sealed class MacroprogramMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(int Sheet, int Limit), MacroprogramPaginateQuery>()
            .Map(dest => dest.Page, src => src.Sheet)
            .Map(dest => dest.Limit, src => src.Limit);

        config.NewConfig<Guid, MacroprogramDetailQuery>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<Guid, MacroprogramRemoveCommand>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<Guid, MacroprogramArchiveCommand>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<Guid, MacroprogramUnarchiveCommand>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<MacroprogramDetailDto, Guid>()
            .MapWith(src => src.Id);
    }
}