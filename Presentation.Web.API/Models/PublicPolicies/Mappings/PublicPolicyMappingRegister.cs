using Mapster;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.PublicPolicy.CQRS.Command;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PublicPolicies.CQRS.Command.Archive;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PublicPolicies.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PublicPolicies.CQRS.Command.Remove;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PublicPolicies.CQRS.Command.Unarchive;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PublicPolicies.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PublicPolicies.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PublicPolicies.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.API.Models.PublicPolicies.Mappings;
// TODO Rename PublicPolicys a PublicPolicies
internal class PublicPolicyMappingRegister : IRegister
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
