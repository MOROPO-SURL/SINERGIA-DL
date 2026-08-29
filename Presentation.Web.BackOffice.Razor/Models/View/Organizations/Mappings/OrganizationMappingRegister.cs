using Mapster;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Organizations.CQRS.Command.Archive;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Organizations.CQRS.Command.Disable;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Organizations.CQRS.Command.Enable;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Organizations.CQRS.Command.Remove;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Organizations.CQRS.Command.Unarchive;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Organizations.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Organizations.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Organizations.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Models.View.Organizations.Mappings;

internal sealed class OrganizationMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(int Sheet, int Limit), OrganizationPaginateQuery>()
            .Map(dest => dest.Page, src => src.Sheet)
            .Map(dest => dest.Limit, src => src.Limit);

        config.NewConfig<Guid, OrganizationDetailQuery>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<Guid, OrganizationRemoveCommand>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<Guid, OrganizationArchiveCommand>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<Guid, OrganizationUnarchiveCommand>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<Guid, OrganizationEnableCommand>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<Guid, OrganizationDisableCommand>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<OrganizationDetailDto, Guid>()
            .MapWith(src => src.Id);
    }
}