using Mapster;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Macroprograms.CQRS.Command.Archive;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Macroprograms.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Macroprograms.CQRS.Command.Remove;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Macroprograms.CQRS.Command.Unarchive;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Macroprograms.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Macroprograms.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Macroprograms.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Macroprogram.CQRS.Command;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.API.Models.Macroprograms.Mappings;

internal class MacroprogramMappingRegister: IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(int Sheet, int Limit), MacroprogramPaginateQuery>()
            .Map(dest => dest.Page, src => src.Sheet)
            .Map(dest => dest.Limit, src => src.Limit);

        config.NewConfig<MacroprogramDetailDto, Guid>()
            .MapWith(src => src.Id);

        config.NewConfig<Guid, MacroprogramDetailQuery>()
            .MapWith(src => new MacroprogramDetailQuery(src));

        config.NewConfig<Guid, MacroprogramRemoveCommand>()
            .MapWith(src => new MacroprogramRemoveCommand(src));

        config.NewConfig<Guid, MacroprogramArchiveCommand>()
            .MapWith(src => new MacroprogramArchiveCommand(src));

        config.NewConfig<Guid, MacroprogramUnarchiveCommand>()
            .MapWith(src => new MacroprogramUnarchiveCommand(src));

        config.NewConfig<MacroprogramCreateRequestModel, MacroprogramCreateCommand>()
            .Map(dest => dest.Id, src => Guid.NewGuid())
            .Map(dest => dest, src => src);
    }
}
