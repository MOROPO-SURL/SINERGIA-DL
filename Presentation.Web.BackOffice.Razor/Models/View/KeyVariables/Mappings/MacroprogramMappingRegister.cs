using Mapster;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.KeyVariables.CQRS.Command.Archive;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.KeyVariables.CQRS.Command.Remove;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.KeyVariables.CQRS.Command.Unarchive;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.KeyVariables.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.KeyVariables.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.KeyVariables.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.KeyVariables.Mappings;

internal sealed class KeyVariableMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(int Sheet, int Limit), KeyVariablePaginateQuery>()
            .Map(dest => dest.Page, src => src.Sheet)
            .Map(dest => dest.Limit, src => src.Limit);

        config.NewConfig<Guid, KeyVariableDetailQuery>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<Guid, KeyVariableRemoveCommand>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<Guid, KeyVariableArchiveCommand>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<Guid, KeyVariableUnarchiveCommand>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<KeyVariableDetailDto, Guid>()
            .MapWith(src => src.Id);
    }
}