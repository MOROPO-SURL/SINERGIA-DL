using Mapster;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Persons.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Persons.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Persons.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Persons.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PersonAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PersonAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Persons.Mappings;

internal sealed class PersonEntityMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Guid, PersonId>()
            .MapWith(src => new PersonId(src));

        config.NewConfig<Person, PersonBasicDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.Image, src => src.Image.Adapt<ImageBasicDto>())
            .Map(dest => dest, src => src);

        config.NewConfig<Person, PersonDetailDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.EmailAddresses, src => src.EmailAddresses.Select(entity => entity.Adapt<EmailAddressDetailDto>()))
            .Map(dest => dest.PhoneNumbers, src => src.PhoneNumbers.Select(entity => entity.Adapt<PhoneNumberDetailDto>()))
            .Map(dest => dest.PostalAddresses, src => src.PostalAddresses.Select(entity => entity.Adapt<PostalAddressDetailDto>()))
            .Map(dest => dest.WebSiteAddresses, src => src.WebSiteAddresses.Select(entity => entity.Adapt<WebSiteAddressDetailDto>()))
            .Map(dest => dest.Image, src => src.Image.Adapt<ImageBasicDto>())
            .Map(dest => dest, src => src);

        config.NewConfig<PersonDetailQuery, PersonId>()
            .MapWith(src => new PersonId(src.Id));

        config.NewConfig<PersonCreateCommand, Person>()
            .MapWith(src => new(
                new PersonId(Guid.NewGuid()),
                src.Priority,
                src.IsEnabled,
                false,
                src.Name,
                src.Sex,
                src.CivilStatus,
                src.EmailAddresses.Select(item => item.Adapt<EmailAddress>()).ToArray(),
                src.PhoneNumbers.Select(item => item.Adapt<PhoneNumber>()).ToArray(),
                src.PostalAddresses.Select(item => item.Adapt<PostalAddress>()).ToArray(),
                src.WebSiteAddresses.Select(item => item.Adapt<WebSiteAddress>()).ToArray(),
                src.LastName,
                src.Alias,
                null,
                src.About,
                null,
                null
            ));

        config.NewConfig<PersonUpdateCommand, Person>()
            .Map(dest => dest.Id, src => new PersonId(src.Id))
            .Map(dest => dest, src => src)
            .AfterMapping((src, dest) =>
            {
                foreach (PhoneNumberDetailDto item in src.InPhoneNumbers)
                {
                    dest.Add(item.Adapt<PhoneNumber>());
                }

                foreach (PhoneNumberDetailDto item in src.OutPhoneNumbers)
                {
                    dest.Remove(item.Adapt<PhoneNumber>());
                }

                foreach (EmailAddressDetailDto item in src.InEmailAddresses)
                {
                    dest.Add(item.Adapt<EmailAddress>());
                }

                foreach (EmailAddressDetailDto item in src.OutEmailAddresses)
                {
                    dest.Remove(item.Adapt<EmailAddress>());
                }

                foreach (var item in src.InPostalAddresses)
                {
                    dest.Add(item.Adapt<PostalAddress>());
                }

                foreach (var item in src.OutPostalAddresses)
                {
                    dest.Remove(item.Adapt<PostalAddress>());
                }

                foreach (var item in src.InWebSiteAddresses)
                {
                    dest.Add(item.Adapt<WebSiteAddress>());
                }

                foreach (var item in src.OutWebSiteAddresses)
                {
                    dest.Remove(item.Adapt<WebSiteAddress>());
                }
            });
    }
}
