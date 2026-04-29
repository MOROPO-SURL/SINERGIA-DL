using Mapster;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PublicPolicies.CQRS.Command.Archive;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PublicPolicies.CQRS.Command.Remove;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PublicPolicies.CQRS.Command.Unarchive;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PublicPolicies.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PublicPolicies.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PublicPolicies.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.PublicPolicies.Mappings;

internal sealed class PublicPolicyMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(int Sheet, int Limit), PublicPolicyPaginateQuery>()
            .Map(dest => dest.Page, src => src.Sheet)
            .Map(dest => dest.Limit, src => src.Limit);

        config.NewConfig<Guid, PublicPolicyDetailQuery>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<Guid, PublicPolicyRemoveCommand>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<Guid, PublicPolicyArchiveCommand>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<Guid, PublicPolicyUnarchiveCommand>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<PublicPolicyDetailDto, Guid>()
            .MapWith(src => src.Id);
    }
}
