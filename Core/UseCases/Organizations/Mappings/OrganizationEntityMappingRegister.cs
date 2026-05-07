using Mapster;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Organizations.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Organizations.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Organizations.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Organizations.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationKindAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Organizations.Mappings;

internal sealed class OrganizationEntityMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Guid, OrganizationId>()
            .MapWith(src => new OrganizationId(src));

        config.NewConfig<Organization, OrganizationBasicDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.Image, src => src.Image.Adapt<ImageBasicDto>())
            .Map(dest => dest, src => src);

        config.NewConfig<Organization, OrganizationDetailDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.EmailAddresses, src => src.EmailAddresses.Select(entity => entity.Adapt<EmailAddressDetailDto>()))
            .Map(dest => dest.PhoneNumbers, src => src.PhoneNumbers.Select(entity => entity.Adapt<PhoneNumberDetailDto>()))
            .Map(dest => dest.PostalAddresses, src => src.PostalAddresses.Select(entity => entity.Adapt<PostalAddressDetailDto>()))
            .Map(dest => dest.WebSiteAddresses, src => src.WebSiteAddresses.Select(entity => entity.Adapt<WebSiteAddressDetailDto>()))
            .Map(dest => dest.Image, src => src.Image.Adapt<ImageBasicDto>())
            .Map(dest => dest, src => src);

        config.NewConfig<OrganizationDetailQuery, OrganizationId>()
            .MapWith(src => new OrganizationId(src.Id));

        config.NewConfig<OrganizationCreateCommand, Organization>()
            .MapWith(src => new(
                new OrganizationId(Guid.NewGuid()),
                false,
                src.IsEnabled,
                src.Name,
                src.Priority,
                new OrganizationKindId(src.OrganizationKindId),
                src.EmailAddresses.Select(item => item.Adapt<EmailAddress>()).ToArray(),
                src.PhoneNumbers.Select(item => item.Adapt<PhoneNumber>()).ToArray(),
                src.PostalAddresses.Select(item => item.Adapt<PostalAddress>()).ToArray(),
                src.WebSiteAddresses.Select(item => item.Adapt<WebSiteAddress>()).ToArray(),
                null,
                null,
                null,
                src.About,
                null,
                null
            ));

        config.NewConfig<OrganizationUpdateCommand, Organization>()
            .Map(dest => dest.Id, src => new OrganizationId(src.Id))
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
