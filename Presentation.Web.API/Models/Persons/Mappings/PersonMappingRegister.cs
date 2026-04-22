using Mapster;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Persons.CQRS.Command.Archive;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Persons.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Persons.CQRS.Command.Disable;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Persons.CQRS.Command.Enable;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Persons.CQRS.Command.Remove;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Persons.CQRS.Command.Unarchive;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Persons.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Persons.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Persons.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Persons.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Person.CQRS.Command;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.API.Models.Persons.Mappings;

internal class PersonMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(int Sheet, int Limit), PersonPaginateQuery>()
            .Map(dest => dest.Page, src => src.Sheet)
            .Map(dest => dest.Limit, src => src.Limit);

        config.NewConfig<PersonDetailDto, Guid>()
            .MapWith(src => src.Id);

        config.NewConfig<Guid, PersonDetailQuery>()
            .MapWith(src => new PersonDetailQuery(src));

        config.NewConfig<Guid, PersonRemoveCommand>()
            .MapWith(src => new PersonRemoveCommand(src));

        config.NewConfig<Guid, PersonEnableCommand>()
            .MapWith(src => new PersonEnableCommand(src));

        config.NewConfig<Guid, PersonDisableCommand>()
            .MapWith(src => new PersonDisableCommand(src));

        config.NewConfig<Guid, PersonArchiveCommand>()
            .MapWith(src => new PersonArchiveCommand(src));

        config.NewConfig<Guid, PersonUnarchiveCommand>()
            .MapWith(src => new PersonUnarchiveCommand(src));

        config.NewConfig<PersonCreateRequestModel, PersonCreateCommand>()
            .Map(dest => dest.EmailAddresses, src => src.EmailAddresses.Select(item => item.Adapt<EmailAddressDetailDto>()))
            .Map(dest => dest.PhoneNumbers, src => src.PhoneNumbers.Select(item => item.Adapt<PhoneNumberDetailDto>()))
            .Map(dest => dest.PostalAddresses, src => src.PostalAddresses.Select(item => item.Adapt<PostalAddressDetailDto>()))
            .Map(dest => dest.WebSiteAddresses, src => src.WebSiteAddresses.Select(item => item.Adapt<WebSiteAddressDetailDto>()))
            .Map(dest => dest, src => src);

        config.NewConfig<PersonUpdateRequestModel, PersonUpdateCommand>()
            .Map(dest => dest.EmailAddresses, src => src.EmailAddresses.Select(item => item.Adapt<EmailAddressDetailDto>()))
            .Map(dest => dest.PhoneNumbers, src => src.PhoneNumbers.Select(item => item.Adapt<PhoneNumberDetailDto>()))
            .Map(dest => dest.PostalAddresses, src => src.PostalAddresses.Select(item => item.Adapt<PostalAddressDetailDto>()))
            .Map(dest => dest.WebSiteAddresses, src => src.WebSiteAddresses.Select(item => item.Adapt<WebSiteAddressDetailDto>()))
            .Map(dest => dest, src => src);
    }
}