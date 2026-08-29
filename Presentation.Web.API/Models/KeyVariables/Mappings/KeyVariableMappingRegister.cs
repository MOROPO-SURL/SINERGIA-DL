using Mapster;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.KeyVariables.CQRS.Command.Archive;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.KeyVariables.CQRS.Command.Remove;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.KeyVariables.CQRS.Command.Unarchive;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.KeyVariables.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.KeyVariables.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.KeyVariables.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.API.Models.KeyVariables.Mappings;

internal class KeyVariableMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(int Sheet, int Limit), KeyVariablePaginateQuery>()
            .Map(dest => dest.Page, src => src.Sheet)
            .Map(dest => dest.Limit, src => src.Limit);

        config.NewConfig<KeyVariableDetailDto, Guid>()
            .MapWith(src => src.Id);

        config.NewConfig<Guid, KeyVariableDetailQuery>()
            .MapWith(src => new KeyVariableDetailQuery(src));

        config.NewConfig<Guid, KeyVariableRemoveCommand>()
            .MapWith(src => new KeyVariableRemoveCommand(src));

        config.NewConfig<Guid, KeyVariableArchiveCommand>()
            .MapWith(src => new KeyVariableArchiveCommand(src));

        config.NewConfig<Guid, KeyVariableUnarchiveCommand>()
            .MapWith(src => new KeyVariableUnarchiveCommand(src));
    }
}