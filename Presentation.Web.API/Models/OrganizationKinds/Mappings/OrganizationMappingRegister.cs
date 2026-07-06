using Mapster;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OrganizationKinds.CQRS.Command.Disable;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OrganizationKinds.CQRS.Command.Enable;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OrganizationKinds.CQRS.Command.Remove;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OrganizationKinds.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OrganizationKinds.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OrganizationKinds.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.API.Models.FeatureKinds.Mappings;

internal class OrganizationKindMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(int Sheet, int Limit), OrganizationKindPaginateQuery>()
            .Map(dest => dest.Page, src => src.Sheet)
            .Map(dest => dest.Limit, src => src.Limit);

        config.NewConfig<OrganizationKindDetailDto, Guid>()
            .MapWith(src => src.Id);

        config.NewConfig<Guid, OrganizationKindDetailQuery>()
            .MapWith(src => new OrganizationKindDetailQuery(src));

        config.NewConfig<Guid, OrganizationKindRemoveCommand>()
            .MapWith(src => new OrganizationKindRemoveCommand(src));

        config.NewConfig<Guid, OrganizationKindEnableCommand>()
            .MapWith(src => new OrganizationKindEnableCommand(src));

        config.NewConfig<Guid, OrganizationKindDisableCommand>()
            .MapWith(src => new OrganizationKindDisableCommand(src));
    }
}