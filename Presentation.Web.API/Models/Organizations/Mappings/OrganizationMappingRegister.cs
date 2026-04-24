using Mapster;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Organizations.CQRS.Command.Archive;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Organizations.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Organizations.CQRS.Command.Disable;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Organizations.CQRS.Command.Enable;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Organizations.CQRS.Command.Remove;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Organizations.CQRS.Command.Unarchive;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Organizations.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Organizations.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Organizations.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Organizations.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Organization.CQRS.Command;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.API.Models.Organizations.Mappings;

internal class OrganizationMappingRegister: IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(int Sheet, int Limit), OrganizationPaginateQuery>()
            .Map(dest => dest.Page, src => src.Sheet)
            .Map(dest => dest.Limit, src => src.Limit);

        config.NewConfig<OrganizationDetailDto, Guid>()
            .MapWith(src => src.Id);

        config.NewConfig<Guid, OrganizationDetailQuery>()
            .MapWith(src => new OrganizationDetailQuery(src));

        config.NewConfig<Guid, OrganizationRemoveCommand>()
            .MapWith(src => new OrganizationRemoveCommand(src));

        config.NewConfig<Guid, OrganizationEnableCommand>()
            .MapWith(src => new OrganizationEnableCommand(src));

        config.NewConfig<Guid, OrganizationDisableCommand>()
            .MapWith(src => new OrganizationDisableCommand(src));

        config.NewConfig<Guid, OrganizationArchiveCommand>()
            .MapWith(src => new OrganizationArchiveCommand(src));

        config.NewConfig<Guid, OrganizationUnarchiveCommand>()
            .MapWith(src => new OrganizationUnarchiveCommand(src));

        config.NewConfig<OrganizationCreateRequestModel, OrganizationCreateCommand>()
            .Map(dest => dest.EmailAddresses, src => src.EmailAddresses.Select(item => item.Adapt<EmailAddressDetailDto>()))
            .Map(dest => dest.PhoneNumbers, src => src.PhoneNumbers.Select(item => item.Adapt<PhoneNumberDetailDto>()))
            .Map(dest => dest.PostalAddresses, src => src.PostalAddresses.Select(item => item.Adapt<PostalAddressDetailDto>()))
            .Map(dest => dest.WebSiteAddresses, src => src.WebSiteAddresses.Select(item => item.Adapt<WebSiteAddressDetailDto>()))
            .Map(dest => dest, src => src);

        config.NewConfig<OrganizationUpdateRequestModel, OrganizationUpdateCommand>()
            .Map(dest => dest.EmailAddresses, src => src.EmailAddresses.Select(item => item.Adapt<EmailAddressDetailDto>()))
            .Map(dest => dest.PhoneNumbers, src => src.PhoneNumbers.Select(item => item.Adapt<PhoneNumberDetailDto>()))
            .Map(dest => dest.PostalAddresses, src => src.PostalAddresses.Select(item => item.Adapt<PostalAddressDetailDto>()))
            .Map(dest => dest.WebSiteAddresses, src => src.WebSiteAddresses.Select(item => item.Adapt<WebSiteAddressDetailDto>()))
            .Map(dest => dest, src => src);
    }
}
