using Mapster;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.FeatureKinds.CQRS.Command.Disable;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.FeatureKinds.CQRS.Command.Enable;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.FeatureKinds.CQRS.Command.Remove;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.FeatureKinds.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.FeatureKinds.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.FeatureKinds.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.API.Models.OrganizationKinds.Mappings;

internal class FeatureKindMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(int Sheet, int Limit), FeatureKindPaginateQuery>()
            .Map(dest => dest.Page, src => src.Sheet)
            .Map(dest => dest.Limit, src => src.Limit);

        config.NewConfig<FeatureKindDetailDto, Guid>()
            .MapWith(src => src.Id);

        config.NewConfig<Guid, FeatureKindDetailQuery>()
            .MapWith(src => new FeatureKindDetailQuery(src));

        config.NewConfig<Guid, FeatureKindRemoveCommand>()
            .MapWith(src => new FeatureKindRemoveCommand(src));

        config.NewConfig<Guid, FeatureKindEnableCommand>()
            .MapWith(src => new FeatureKindEnableCommand(src));

        config.NewConfig<Guid, FeatureKindDisableCommand>()
            .MapWith(src => new FeatureKindDisableCommand(src));
    }
}