using Mapster;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PublicPolicys.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PublicPolicys.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PublicPolicys.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PublicPolicys.CQRS.Command.Remove;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PublicPolicys.CQRS.Command.Archive;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PublicPolicys.CQRS.Command.Unarchive;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PublicPolicys.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.PublicPolicy.CQRS.Command;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.API.Models.PublicPolicys.Mappings;

internal class PublicPolicyMappingRegister: IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(int Sheet, int Limit), PublicPolicyPaginateQuery>()
            .Map(dest => dest.Page, src => src.Sheet)
            .Map(dest => dest.Limit, src => src.Limit);

        config.NewConfig<PublicPolicyDetailDto, Guid>()
            .MapWith(src => src.Id);

        config.NewConfig<Guid, PublicPolicyDetailQuery>()
            .MapWith(src => new PublicPolicyDetailQuery(src));

        config.NewConfig<Guid, PublicPolicyRemoveCommand>()
            .MapWith(src => new PublicPolicyRemoveCommand(src));

        config.NewConfig<Guid, PublicPolicyArchiveCommand>()
            .MapWith(src => new PublicPolicyArchiveCommand(src));

        config.NewConfig<Guid, PublicPolicyUnarchiveCommand>()
            .MapWith(src => new PublicPolicyUnarchiveCommand(src));

        config.NewConfig<PublicPolicyCreateRequestModel, PublicPolicyCreateCommand>()
            .Map(dest => dest.Id, src => Guid.NewGuid())
            .Map(dest => dest, src => src);
    }
}
