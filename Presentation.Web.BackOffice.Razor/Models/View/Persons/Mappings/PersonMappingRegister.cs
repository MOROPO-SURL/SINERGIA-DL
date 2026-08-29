using Mapster;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Persons.CQRS.Command.Archive;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Persons.CQRS.Command.Disable;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Persons.CQRS.Command.Enable;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Persons.CQRS.Command.Remove;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Persons.CQRS.Command.Unarchive;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Persons.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Persons.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Persons.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Models.View.Persons.Mappings;

internal sealed class PersonMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(int Sheet, int Limit), PersonPaginateQuery>()
            .Map(dest => dest.Page, src => src.Sheet)
            .Map(dest => dest.Limit, src => src.Limit);

        config.NewConfig<Guid, PersonDetailQuery>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<Guid, PersonRemoveCommand>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<Guid, PersonArchiveCommand>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<Guid, PersonUnarchiveCommand>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<Guid, PersonEnableCommand>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<Guid, PersonDisableCommand>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<PersonDetailDto, Guid>()
            .MapWith(src => src.Id);
    }
}